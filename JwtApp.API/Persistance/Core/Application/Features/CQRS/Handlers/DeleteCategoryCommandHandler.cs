using JwtApp.API.Persistance.Core.Application.Features.CQRS.Commands;
using JwtApp.API.Persistance.Core.Application.Interfaces;
using JwtApp.API.Persistance.Core.Domain;
using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepository<Category> _repository;

        public DeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByFilter(x=>x.Id == request.Id);
            await _repository.DeleteAsync(value);
            return Unit.Value;
        }
    }
}
