using Project1.DTOs;

namespace Project1.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProductsAsync();

        Task<ProductDTO> GetProductByIdAsync(int id);

        Task<ProductDTO> CreateProductAsync(CreateProductDTO productDTO);

        Task<ProductDTO> UpdateProductAsync(int id, UpdateProductDTO productDTO);

        Task DeleteProductAsync(int id);
    }
}