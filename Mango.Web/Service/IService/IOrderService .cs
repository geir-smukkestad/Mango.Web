using Mango.Common.Dto;
using Mango.Web.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Mango.Web.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDto?> CreateOrder(CartDto cartDto);
        Task<ResponseDto?> CreateStripeSession(StripeRequestDto stripeRequestDto);
    }
}