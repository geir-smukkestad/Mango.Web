using Mango.Common.Dto;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Mango.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
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
