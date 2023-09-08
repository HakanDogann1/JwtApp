using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Commands
{
    public class RegisterUserCommand:IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
