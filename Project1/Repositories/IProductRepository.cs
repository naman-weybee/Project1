using Project1.DTOs;
using Project1.Models;

namespace Project1.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> GetAllAsync();

        Task<ProductDTO> GetByIdAsync(int id);

        Task<ProductDTO> AddAsync(Product product);

        Task<ProductDTO> UpdateAsync(int id, Product product);

        Task DeleteAsync(int id);
    }
}