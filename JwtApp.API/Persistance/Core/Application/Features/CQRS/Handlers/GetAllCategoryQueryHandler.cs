using AutoMapper;
using JwtApp.API.Persistance.Core.Application.DTOs;
using JwtApp.API.Persistance.Core.Application.Features.CQRS.Queries;
using JwtApp.API.Persistance.Core.Application.Interfaces;
using JwtApp.API.Persistance.Core.Domain;
using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Handlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryResult, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;
        public GetAllCategoryQueryHandler(IRepository<Category> repository, AutoMapper.IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetAllCategoryQueryResult request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryListDto>>(values);
        }
    }
}
