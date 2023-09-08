using JwtApp.API.Persistance.Core.Application.DTOs;
using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Queries
{
    public class GetByIdProductQueryResult:IRequest<ProductListDto>
    {
        public int Id { get; set; }

        public GetByIdProductQueryResult(int ıd)
        {
            Id = ıd;
        }
    }
}
