using AutoMapper;
using JwtApp.API.Persistance.Core.Application.DTOs;
using JwtApp.API.Persistance.Core.Domain;

namespace JwtApp.API.Persistance.Core.Application.Mappings
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryListDto>().ReverseMap();
        }
    }
}
