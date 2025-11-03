using Mango.Common.Dto;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Mango.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [Authorize]
        public async Task<IActionResult> ShoppingCartIndex()
        {
            return View(await LoadCartDtoBaseOnLoggedInUser());
        }

        public async Task<IActionResult> Remove(int cartDetailsId)
        {
            ResponseDto? response = await _shoppingCartService.RemoveFromCartAsync(cartDetailsId);
            if (response != null && response.IsSuccessFul)
            {
                TempData["success"] = "Item successfully removed from cart";
                return RedirectToAction(nameof(ShoppingCartIndex));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ApplyCoupon(CartDto cartDto)
        {            
            ResponseDto? response = await _shoppingCartService.ApplyCouponAsync(cartDto);
            if (response != null && response.IsSuccessFul)
            {
                TempData["success"] = "Coupon code successfully applied";
                return RedirectToAction(nameof(ShoppingCartIndex));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmailCart(CartDto cartDto)
        {
            CartDto cart = await LoadCartDtoBaseOnLoggedInUser();
            cart.CartHeader.Email = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Email)?.FirstOrDefault()?.Value;

            ResponseDto? response = await _shoppingCartService.EmailCart(cart);
            if (response != null && response.IsSuccessFul)
            {
                TempData["success"] = "Email will be processed and sent shortly";
                return RedirectToAction(nameof(ShoppingCartIndex));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCoupon(CartDto cartDto)
        {
            cartDto.CartHeader.CouponCode = "";
            ResponseDto? response = await _shoppingCartService.ApplyCouponAsync(cartDto);
            if (response != null && response.IsSuccessFul)
            {
                TempData["success"] = "Coupon code successfully removed";
                return RedirectToAction(nameof(ShoppingCartIndex));
            }
            return View();
        }


        private async Task<CartDto> LoadCartDtoBaseOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? response = await _shoppingCartService.GetCartByUserId(userId!);
            if (response != null && response.IsSuccessFul)
            {
                CartDto cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(response.Result))!;
                return cartDto;
            }
            return new CartDto();
        }
    }
}
