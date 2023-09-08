using JwtApp.API.Persistance.Core.Application.DTOs;
using JwtApp.API.Persistance.Core.Application.Features.CQRS.Queries;
using JwtApp.API.Persistance.Core.Application.Interfaces;
using JwtApp.API.Persistance.Core.Domain;
using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Handlers
{
	public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryResult, CheckUserResponseDto>
	{
		private readonly IRepository<AppUser> _repositoryUser;
		private readonly IRepository<AppRole>  _repositoryRole;

		public CheckUserQueryHandler(IRepository<AppUser> repositoryUser, IRepository<AppRole> repositoryRole)
		{
			_repositoryUser = repositoryUser;
			_repositoryRole = repositoryRole;
		}

		public async Task<CheckUserResponseDto> Handle(CheckUserQueryResult request, CancellationToken cancellationToken)
		{
			var value = await _repositoryUser.GetByFilter(x=>x.UserName==request.UserName && x.Password==request.Password);
			if(value!=null)
			{
				var role = await _repositoryRole.GetByFilter(x => x.Id == value.AppRoleId);

				return new CheckUserResponseDto
				{
					Exist = true,
					Id=value.Id,
					UserName = request.UserName,
					Role=role.Definition
				};
			}
			return new CheckUserResponseDto
			{
				Exist = false,
			};
		}
	}
}
