using Project1.AutoMapper;
using Project1.DTOs;
using Project1.Models;
using Project1.Repositories;
using Project1.RequestModel;
using X.PagedList;

namespace Project1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly Mapper _mapper;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
            _mapper = new Mapper();
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync(RequestParams requestParams)
        {
            var items = await _repository.GetAllAsync(requestParams);

            return await items?.Select(item => new CategoryDTO
            {
                Id = item.Id,
                ParentCategoryId = item.ParentCategoryId,
                Name = item.Name,
                Level = item.Level
            }).ToListAsync();
        }

        public async Task<List<CategoryTreeDTO>> GetCategoryTreeAsync()
        {
            var items = await _repository.GetAllWithoutPaginationAsync();
            var categoryList = items?.ToList() ?? new List<Category>();

            return BuildCategoryTree(categoryList);
        }

        internal List<CategoryTreeDTO> BuildCategoryTree(List<Category> categories, int? parentId = null)
        {
            return categories
                .Where(c => c.ParentCategoryId == parentId)
                .Select(c => new CategoryTreeDTO
                {
                    Id = c.Id,
                    ParentCategoryId = c.ParentCategoryId,
                    Name = c.Name,
                    Level = c.Level,
                    ChildCategories = BuildCategoryTree(categories, c.Id)
                }).ToList();
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);

            return _mapper.CategoryMapper(item);
        }

        public async Task CreateCategoryAsync(CreateCategoryDTO _dto)
        {
            var item = new Category
            {
                ParentCategoryId = _dto.ParentCategoryId,
                Name = _dto.Name,
                Level = _dto.Level
            };

            await _repository.InsertAsync(item);
        }

        public async Task UpdateCategoryAsync(CategoryDTO _dto)
        {
            var item = new Category
            {
                Id = _dto.Id,
                ParentCategoryId = _dto.ParentCategoryId,
                Name = _dto.Name,
                Level = _dto.Level
            };

            await _repository.UpdateAsync(item);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}