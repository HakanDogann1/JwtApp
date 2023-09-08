using JwtApp.API.Persistance.Core.Application.DTOs;
using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Queries
{
	public class CheckUserQueryResult:IRequest<CheckUserResponseDto>
	{
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
