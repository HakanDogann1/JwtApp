using JwtApp.Front.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtApp.Front.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public IActionResult Login()
        {
            return View(new LoginDto());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if(!ModelState.IsValid)
            {
         
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7060/api/Auth/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var djsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonConvert.DeserializeObject<JwtTokenResponseModel>(djsonData);
                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);

                    var claimsIdentity = new ClaimsIdentity(token.Claims, JwtBearerDefaults.AuthenticationScheme);
                    var claims = new ClaimsPrincipal(claimsIdentity);
                    var authProp = new AuthenticationProperties
                    {
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, claims, authProp);
                }
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Yanlış");
                return View();
            }
        }
    }
}
