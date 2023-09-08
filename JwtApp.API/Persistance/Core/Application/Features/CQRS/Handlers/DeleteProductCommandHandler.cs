using JwtApp.API.Persistance.Core.Application.Features.CQRS.Commands;
using JwtApp.API.Persistance.Core.Application.Interfaces;
using JwtApp.API.Persistance.Core.Domain;
using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByFilter(x=>x.Id==request.Id);
            await _repository.DeleteAsync(value);
            return Unit.Value;
        }
    }
}
