using JwtApp.API.Persistance.Core.Application.DTOs;
using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Queries
{
    public class GetAllCategoryQueryResult:IRequest<List<CategoryListDto>>
    {
    }
}
