using Project1.AutoMapper;
using Project1.Configurations;
using Project1.DTOs;
using Project1.Models;
using Project1.Repositories;

namespace Project1.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product, AppDbContext> _repository;
        private readonly Mapper _mapper;

        public ProductService(IRepository<Product, AppDbContext> repository)
        {
            _repository = repository;
            _mapper = new Mapper();
        }

        //public async Task<List<ProductDTO>> GetAllProductsAsync()
        //{
        //    return await _productRepository.GetAllAsync();
        //}

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            return _mapper.ProductMapper(product);
        }

        public async Task CreateProductAsync(CreateProductDTO productDTO)
        {
            var product = new Product
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Stock = productDTO.Stock
            };

            await _repository.InsertAsync(product);
        }

        public async Task UpdateProductAsync(ProductDTO productDTO)
        {
            var product = new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Stock = productDTO.Stock
            };

            await _repository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}