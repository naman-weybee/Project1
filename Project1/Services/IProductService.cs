using Project1.DTOs;
using Project1.RequestModel;

namespace Project1.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProductsAsync(RequestParams requestParams);

        Task<ProductDTO> GetProductByIdAsync(int id);

        Task CreateProductAsync(CreateProductDTO productDTO);

        Task UpdateProductAsync(ProductDTO productDTO);

        Task DeleteProductAsync(int id);
    }
}