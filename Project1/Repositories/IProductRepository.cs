using Project1.DTOs;
using Project1.Models;
using Project1.RequestModel;
using X.PagedList;

namespace Project1.Repositories
{
    public interface IProductRepository
    {
        //Task<IPagedList<ProductDTO>> GetAllAsync(RequestParams requestParams);

        Task<ProductDTO> GetByIdAsync(int id);

        Task<ProductDTO> AddAsync(Product product);

        Task<ProductDTO> UpdateAsync(int id, Product product);

        Task DeleteAsync(int id);
    }
}