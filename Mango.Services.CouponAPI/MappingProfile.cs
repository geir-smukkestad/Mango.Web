using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Common.Dto;

namespace Mango.Services.CouponAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CouponDto, Coupon>().ForMember(dest => dest.CouponId, opt => opt.Ignore()); // Ignore CouponId, EF Core will auto-generate it
            CreateMap<Coupon, CouponDto>();
        }
    }
}
