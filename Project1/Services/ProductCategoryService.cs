using AutoMapper;
using Project1.DTOs;
using Project1.Models;
using Project1.Repositories;
using Project1.RequestModel;

namespace Project1.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory> _repository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryService(IRepository<ProductCategory> repository, IRepository<Product> productRepository, IRepository<Category> categoryRepository, IMapper mapper)
        {
            _repository = repository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductCategoryDTO>> GetAllProductCategoriesAsync(RequestParams requestParams)
        {
            var items = await _repository.GetAllAsync(requestParams);

            return _mapper.Map<List<ProductCategoryDTO>>(items);
        }

        public async Task<List<ProductCategoryDetailedDTO>> GetAllDetailedProductCategoriesAsync(RequestParams requestParams)
        {
            var items = await _repository.GetAllAsync(requestParams);

            if (items.Any())
            {
                var productCategoryList = new List<ProductCategoryDetailedDTO>();
                foreach (var item in items)
                {
                    if (item == null)
                        continue;

                    var product = await _productRepository.GetByIdAsync(item.ProductId);
                    var category = await _categoryRepository.GetByIdAsync(item.CategoryId);

                    if (product == null || category == null)
                        continue;

                    var productCategory = new ProductCategoryDetailedDTO()
                    {
                        ProductId = item.ProductId,
                        CategoryId = item.CategoryId,
                        ProductName = product.Name,
                        CategoryName = category.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Stock = product.Stock
                    };

                    productCategoryList.Add(productCategory);
                }

                return productCategoryList;
            }

            return null;
        }

        public async Task<ProductCategoryDTO> GetProductCategoryByIdAsync(int id1, int id2)
        {
            var item = await _repository.GetByIdAsync(id1, id2);
            if (item != null)
                return _mapper.Map<ProductCategoryDTO>(item);

            return null;
        }

        public async Task<ProductCategoryDetailedDTO> GetDetailedProductCategoryByIdAsync(int id1, int id2)
        {
            var item = await _repository.GetByIdAsync(id1, id2);
            if (item != null)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                var category = await _categoryRepository.GetByIdAsync(item.CategoryId);

                if (product != null || category != null)
                {
                    return new ProductCategoryDetailedDTO()
                    {
                        ProductId = item.ProductId,
                        CategoryId = item.CategoryId,
                        ProductName = product.Name,
                        CategoryName = category.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Stock = product.Stock
                    };
                }
            }

            return null;
        }

        public async Task CreateProductCategoryAsync(ProductCategoryDTO _dto)
        {
            var item = _mapper.Map<ProductCategory>(_dto);

            await _repository.InsertAsync(item);
        }

        public async Task UpdateProductCategoryAsync(int id1, int id2, ProductCategoryDTO _dto)
        {
            var item = await _repository.GetByIdAsync(id1, id2);
            if (item != null)
            {
                await _repository.DeleteAsync(id1, id2);

                var newItem = _mapper.Map<ProductCategory>(_dto);

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