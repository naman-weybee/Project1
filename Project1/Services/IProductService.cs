using Project1.DTOs;
using Project1.RequestModel;

namespace Project1.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProductsAsync(RequestParams _dto);

        Task<ProductDTO> GetProductByIdAsync(int id);

        Task CreateProductAsync(CreateProductDTO _dto);

        Task UpdateProductAsync(ProductDTO _dto);

        Task DeleteProductAsync(int id);
    }
}