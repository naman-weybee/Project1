using Project1.DTOs;
using Project1.Models;

namespace Project1.Services
{
    public interface IProductService
    {
        //Task<List<ProductDTO>> GetAllProductsAsync();

        Task<ProductDTO> GetProductByIdAsync(int id);

        Task CreateProductAsync(CreateProductDTO productDTO);

        Task UpdateProductAsync(ProductDTO productDTO);

        Task DeleteProductAsync(int id);
    }
}