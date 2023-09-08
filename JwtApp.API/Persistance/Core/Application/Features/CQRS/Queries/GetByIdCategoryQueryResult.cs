using JwtApp.API.Persistance.Core.Application.DTOs;
using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Queries
{
    public class GetByIdCategoryQueryResult:IRequest<CategoryListDto>
    {
        public int Id { get; set; }

        public GetByIdCategoryQueryResult(int ıd)
        {
            Id = ıd;
        }
    }
}
