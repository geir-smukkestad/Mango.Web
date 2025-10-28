using Mango.Common.Dto;
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using static Mango.Web.Utility.StaticDetails;

namespace Mango.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateProductAsync(ProductDto product)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.POST,
                Data = product,
                Url = StaticDetails.ProductAPIBase + "/api/product"
            };

            return await _baseService.SendAsync(req);
        }

        public async Task<ResponseDto?> DeleteProductAsync(int id)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.DELETE,
                Url = StaticDetails.ProductAPIBase + "/api/product/" + id
            };

            return await _baseService.SendAsync(req);

        }

        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            var req = new RequestDto
            {
                ApiType = ApiType.GET,
                Url = StaticDetails.ProductAPIBase + "/api/product"
            };

            return await _baseService.SendAsync(req);

        }

        public async Task<ResponseDto?> GetProductFromIdAsync(int id)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.GET,
                Url = StaticDetails.ProductAPIBase + "/api/product/" + id
            };

            return await _baseService.SendAsync(req);

        }

        public async Task<ResponseDto?> UpdateProductAsync(ProductDto product)
        {
            var req = new RequestDto
            {
                ApiType = ApiType.PUT,
                Data = product,
                Url = StaticDetails.ProductAPIBase + "/api/product"
            };

            return await _baseService.SendAsync(req);

        }
    }
}
