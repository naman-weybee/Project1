using Project1.DTOs;
using Project1.Models;
using Project1.Repositories;

namespace Project1.Services
{
    public class ProductService : IProductService
    {
        public IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<ProductDTO> CreateProductAsync(CreateProductDTO productDTO)
        {
            var product = new Product
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Stock = productDTO.Stock
            };

            return await _productRepository.AddAsync(product);
        }

        public async Task<ProductDTO> UpdateProductAsync(int id, UpdateProductDTO productDTO)
        {
            var product = new Product
            {
                Id = id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Stock = productDTO.Stock
            };

            return await _productRepository.UpdateAsync(id, product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}