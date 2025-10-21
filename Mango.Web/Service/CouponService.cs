using Mango.Common.Dto;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using static Mango.Web.Utility.StaticDetails;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDto coupon)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.POST,
                Data = coupon,
                Url = StaticDetails.CouponAPIBase + "/api/coupon"
            };

            return await _baseService.SendAsync(req);
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.DELETE,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/" + id
            };

            return await _baseService.SendAsync(req);
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            var req = new RequestDto
            {
                ApiType = ApiType.GET,
                Url = StaticDetails.CouponAPIBase + "/api/coupon"
            };

            return await _baseService.SendAsync(req);
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.GET,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/GetByCode" + couponCode
            };

            return await _baseService.SendAsync(req);
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.GET,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/" + id
            };

            return await _baseService.SendAsync(req);
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto coupon)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.PUT,
                Data = coupon,
                Url = StaticDetails.CouponAPIBase + "/api/coupon"
            };

            return await _baseService.SendAsync(req);
        }
    }
}
