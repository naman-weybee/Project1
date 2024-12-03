using Project1.DTOs;
using Project1.RequestModel;

namespace Project1.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync(RequestParams _dto);

        Task<CategoryDTO> GetCategoryByIdAsync(int id);

        Task CreateCategoryAsync(CreateCategoryDTO _dto);

        Task UpdateCategoryAsync(CategoryDTO _dto);

        Task DeleteCategoryAsync(int id);
    }
}
