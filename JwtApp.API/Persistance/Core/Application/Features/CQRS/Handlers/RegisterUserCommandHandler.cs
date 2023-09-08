using JwtApp.API.Persistance.Core.Application.Enums;
using JwtApp.API.Persistance.Core.Application.Features.CQRS.Commands;
using JwtApp.API.Persistance.Core.Application.Interfaces;
using JwtApp.API.Persistance.Core.Domain;
using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IRepository<AppUser> _repository;

        public RegisterUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            
            await _repository.CreateAsync(new AppUser
            {
                Password = request.Password,
                UserName = request.UserName,
                AppRoleId=(int)RoleType.Member
            });
            return Unit.Value;
        }
    }
}
