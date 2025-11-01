using Mango.Common.Dto;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using static Mango.Web.Utility.StaticDetails;

namespace Mango.Web.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IBaseService _baseService;

        public ShoppingCartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetCartByUserId(string userId)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.GET,
                Url = StaticDetails.ShoppingCartAPIBase + "/api/cart/GetCart/" + userId
            };

            return await _baseService.SendAsync(req);
        }

        public async Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = StaticDetails.ShoppingCartAPIBase + "/api/cart/CartUpsert"
            };

            return await _baseService.SendAsync(req);
        }

        public async Task<ResponseDto?> RemoveFromCartAsync(int cartDetailsId)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.POST,
                Data = cartDetailsId,
                Url = StaticDetails.ShoppingCartAPIBase + "/api/cart/RemoveCart"
            };

            return await _baseService.SendAsync(req);
        }

        public async Task<ResponseDto?> ApplyCouponAsync(CartDto cartDto)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = StaticDetails.ShoppingCartAPIBase + "/api/cart/ApplyCoupon"
            };

            return await _baseService.SendAsync(req);
        }
    }
}
