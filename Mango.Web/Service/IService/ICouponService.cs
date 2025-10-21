using Mango.Common.Dto;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponAsync(CouponDto coupon);
        Task<ResponseDto?> UpdateCouponAsync(CouponDto coupon);
        Task<ResponseDto?> DeleteCouponAsync(int id);

    }
}