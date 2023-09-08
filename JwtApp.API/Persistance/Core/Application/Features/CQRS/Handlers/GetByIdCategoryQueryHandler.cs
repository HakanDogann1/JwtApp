using AutoMapper;
using JwtApp.API.Persistance.Core.Application.DTOs;
using JwtApp.API.Persistance.Core.Application.Features.CQRS.Queries;
using JwtApp.API.Persistance.Core.Application.Interfaces;
using JwtApp.API.Persistance.Core.Domain;
using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Handlers
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryResult, CategoryListDto>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetByIdCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetByIdCategoryQueryResult request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByFilter(x=>x.Id== request.Id);
            return _mapper.Map<CategoryListDto>(value);
        }
    }
}
