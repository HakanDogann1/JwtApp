using AutoMapper;
using JwtApp.API.Persistance.Core.Application.DTOs;
using JwtApp.API.Persistance.Core.Application.Features.CQRS.Commands;
using JwtApp.API.Persistance.Core.Domain;

namespace JwtApp.API.Persistance.Core.Application.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductListDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,CreateProductCommand>().ReverseMap();
            CreateMap<CreateProductDto,CreateProductCommand>().ReverseMap();
        }
    }
}
