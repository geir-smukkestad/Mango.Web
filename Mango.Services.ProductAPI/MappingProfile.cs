using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>().ForMember(dest => dest.ProductId, opt => opt.Ignore()); // Ignore ProductId, EF Core will auto-generate it
            CreateMap<Product, ProductDto>();
        }
    }
}
