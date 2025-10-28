using Mango.Common.Dto;

namespace Mango.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetAllProductsAsync();
        Task<ResponseDto?> GetProductFromIdAsync(int id);
        Task<ResponseDto?> CreateProductAsync(ProductDto product);
        Task<ResponseDto?> UpdateProductAsync(ProductDto product);
        Task<ResponseDto?> DeleteProductAsync(int id);
    }
}
