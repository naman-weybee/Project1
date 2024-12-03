using Project1.AutoMapper;
using Project1.DTOs;
using Project1.Models;
using Project1.Repositories;
using Project1.RequestModel;
using X.PagedList;

namespace Project1.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory> _repository;
        private readonly Mapper _mapper;

        public ProductCategoryService(IRepository<ProductCategory> repository)
        {
            _repository = repository;
            _mapper = new Mapper();
        }

        public async Task<List<ProductCategoryDTO>> GetAllProductCategoriesAsync(RequestParams requestParams)
        {
            var items = await _repository.GetAllAsync(requestParams);

            return await items?.Select(item => new ProductCategoryDTO
            {
                ProductId = item.ProductId,
                CategoryId = item.CategoryId
            }).ToListAsync();
        }

        public async Task<ProductCategoryDTO> GetProductCategoryByIdAsync(int id1, int id2)
        {
            var item = await _repository.GetByIdAsync(id1, id2);

            return _mapper.ProductCategoryMapper(item);
        }

        public async Task CreateProductCategoryAsync(ProductCategoryDTO _dto)
        {
            var item = new ProductCategory
            {
                ProductId = _dto.ProductId,
                CategoryId = _dto.CategoryId
            };

            await _repository.InsertAsync(item);
        }

        public async Task UpdateProductCategoryAsync(int id1, int id2, ProductCategoryDTO _dto)
        {
            var item = await _repository.GetByIdAsync(id1, id2);
            if (item != null)
            {
                await _repository.DeleteAsync(id1, id2);

                var newItem = new ProductCategory
                {
                    ProductId = _dto.ProductId,
                    CategoryId = _dto.CategoryId
                };

                await _repository.InsertAsync(newItem);
            }
            else
            {
                throw new Exception($"Data for Ids = {id1}, {id2} is not Available...!");
            }
        }

        public async Task DeleteProductCategoryAsync(int id1, int id2)
        {
            await _repository.DeleteAsync(id1, id2);
        }
    }
}