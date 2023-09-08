using AutoMapper;
using JwtApp.API.Persistance.Core.Application.DTOs;
using JwtApp.API.Persistance.Core.Application.Features.CQRS.Queries;
using JwtApp.API.Persistance.Core.Application.Interfaces;
using JwtApp.API.Persistance.Core.Domain;
using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Handlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryResult, ProductListDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetByIdProductQueryResult request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ProductListDto>(value);
        }
    }
}
