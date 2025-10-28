using AutoMapper;
using Mango.Common.Dto;
using Mango.Services.ProductAPI.Models;

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
