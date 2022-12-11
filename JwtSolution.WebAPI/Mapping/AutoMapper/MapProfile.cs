using AutoMapper;
using JwtSolution.Dtos.AppUserDtos;
using JwtSolution.Dtos.ProductDtos;
using JwtSolution.Entities.Concrete;

namespace JwtSolution.WebAPI.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductAddDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
            CreateMap<AppUserAddDto, AppUser>().ReverseMap();
        }
    }
}
