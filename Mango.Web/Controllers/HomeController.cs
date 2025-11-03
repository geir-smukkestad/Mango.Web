using Mango.Common.Dto;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace Mango.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;

        public HomeController(IProductService productService, IShoppingCartService shoppingCartService)
        {
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> productList = new();
            ResponseDto? response = await _productService.GetAllProductsAsync();

            if (response != null && response.IsSuccessFul)
                productList = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(response.Result))!.ToList();
            else
                TempData["error"] = response?.Message;

            return View(productList);
        }

        [Authorize]
        public async Task<IActionResult> ProductDetails(int productId)
        {
            ProductDto product = new();
            ResponseDto? response = await _productService.GetProductFromIdAsync(productId);

            if (response != null && response.IsSuccessFul)
                product =  JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            else
                TempData["error"] = response?.Message;

            return View(product);
        }

        [Authorize]
        [HttpPost]
        [ActionName("ProductDetails")]
        public async Task<IActionResult> ProductDetails(ProductDto productDto)
        {
            CartDto cartDto = new CartDto
            {
                CartHeader = new CartHeaderDto
                {
                    UserId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value
                }
            };

            CartDetailsDto cartDetails = new CartDetailsDto
            {
                Count = productDto.Count,
                ProductId = productDto.ProductId
            };

            List<CartDetailsDto> cartDetailsDtos = new List<CartDetailsDto>{ cartDetails };
            cartDto.CartDetails = cartDetailsDtos;

            ResponseDto? response = await _shoppingCartService.UpsertCartAsync(cartDto);

            if (response != null && response.IsSuccessFul)
            {
                TempData["success"] = "Item has been added to the shoppinh cart";
                return RedirectToAction(nameof(Index));
            }
            else
                TempData["error"] = response?.Message;

            return View(productDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
