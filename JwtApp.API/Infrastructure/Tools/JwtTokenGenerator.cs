using JwtApp.API.Persistance.Core.Application.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtApp.API.Infrastructure.Tools
{
	public static class JwtTokenGenerator
	{
		public static TokenResponseDto GenerateToken(CheckUserResponseDto checkUserResponseDto)
		{
			
			var claims = new List<Claim>();
			if(!string.IsNullOrEmpty(checkUserResponseDto.Role))
				claims.Add(new Claim(ClaimTypes.Role, checkUserResponseDto.Role));

				claims.Add(new Claim(ClaimTypes.NameIdentifier, checkUserResponseDto.Id.ToString()));

			if (!string.IsNullOrEmpty(checkUserResponseDto.UserName))
				claims.Add(new Claim("UserName",checkUserResponseDto.UserName));


			var expireDate=DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
			SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			JwtSecurityToken securityToken = new JwtSecurityToken(issuer:JwtTokenDefaults.ValidIssuer,JwtTokenDefaults.ValidAudience,claims:claims,notBefore:DateTime.UtcNow,expires:expireDate,signingCredentials:signingCredentials);
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

			return new TokenResponseDto(handler.WriteToken(securityToken),expireDate);

		}
	}
}
