using JwtApp.API.Infrastructure.Tools;
using JwtApp.API.Persistance.Core.Application.Features.CQRS.Commands;
using JwtApp.API.Persistance.Core.Application.Features.CQRS.Queries;
using JwtApp.API.Persistance.Core.Application.Interfaces;
using JwtApp.API.Persistance.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace JwtApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryResult checkUserQueryResult)
        {
            var value = await _mediator.Send(checkUserQueryResult);
            if(value.Exist==false)
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }

            return Created("", JwtTokenGenerator.GenerateToken(value));
        }
    }
}
