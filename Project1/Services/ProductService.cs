using AutoMapper;
using Project1.DTOs;
using Project1.Models;
using Project1.Repositories;
using Project1.RequestModel;

namespace Project1.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync(RequestParams requestParams)
        {
            var items = await _repository.GetAllAsync(requestParams);

            return _mapper.Map<List<ProductDTO>>(items);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);

            return _mapper.Map<ProductDTO>(item);
        }

        public async Task CreateProductAsync(CreateProductDTO _dto)
        {
            var item = _mapper.Map<Product>(_dto);

            await _repository.InsertAsync(item);
        }

        public async Task UpdateProductAsync(ProductDTO _dto)
        {
            var item = _mapper.Map<Product>(_dto);

            await _repository.UpdateAsync(item);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}