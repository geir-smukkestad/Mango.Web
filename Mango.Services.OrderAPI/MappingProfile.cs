using AutoMapper;
using Mango.Services.OrderAPI.Models;
using Mango.Services.OrderAPI.Models.Dto;

namespace Mango.Services.OrderAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderHeaderDto, CartHeaderDto>()
                .ForMember(dest => dest.CartHeaderId, opt => opt.Ignore())
                .ForMember(dest => dest.CartTotal, u => u.MapFrom(src => src.OrderTotal))
                .ReverseMap();

            CreateMap<CartDetailsDto, OrderDetailsDto>()
                .ForMember(dest => dest.OrderDetailsId, opt => opt.Ignore())
                .ForMember(dest => dest.OrderHeaderId, opt => opt.Ignore())
                .ForMember(dest => dest.ProductName, u => u.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, u => u.MapFrom(src => src.Product.Price));
            CreateMap<OrderDetailsDto, CartDetailsDto>()
                .ForMember(dest => dest.CartDetailsId, opt => opt.Ignore())
                .ForMember(dest => dest.CartHeaderId, opt => opt.Ignore())
                .ForMember(dest => dest.CartHeader, opt => opt.Ignore());

            CreateMap<OrderDetailsDto, OrderDetails>()
                .ForMember(dest => dest.OrderHeader, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
        }

        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }

/*            CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
                CreateMap<OrderDetailsDto, OrderDetails>()
                    .ForMember(dest => dest.OrderHeader, opt => opt.Ignore())
                    .ReverseMap();*/
    }
}
