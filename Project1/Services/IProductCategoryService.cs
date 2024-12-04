using Project1.DTOs;
using Project1.RequestModel;

namespace Project1.Services
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryDTO>> GetAllProductCategoriesAsync(RequestParams requestParams);

        Task<List<ProductCategoryDetailedDTO>> GetAllDetailedProductCategoriesAsync(RequestParams requestParams);

        Task<ProductCategoryDTO> GetProductCategoryByIdAsync(int id1, int id2);


        Task<ProductCategoryDetailedDTO> GetDetailedProductCategoryByIdAsync(int id1, int id2);
        Task CreateProductCategoryAsync(ProductCategoryDTO _dto);

        Task UpdateProductCategoryAsync(int id1, int id2, ProductCategoryDTO _dto);

        Task DeleteProductCategoryAsync(int id1, int id2);
    }
}