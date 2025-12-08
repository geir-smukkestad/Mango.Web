using Mango.Common.Dto;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using static Mango.Web.Utility.StaticDetails;

namespace Mango.Web.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;

        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateOrder(CartDto cartDto)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = StaticDetails.OrderAPIBase + "/api/order/CreateOrder"
            };

            return await _baseService.SendAsync(req);
        }
    }
}
