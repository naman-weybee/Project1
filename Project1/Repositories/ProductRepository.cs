using Microsoft.EntityFrameworkCore;
using Project1.Configurations;
using Project1.DTOs;
using Project1.Models;
using X.PagedList;

namespace Project1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<IPagedList<ProductDTO>> GetAllAsync(RequestParams requestParams)
        //{
        //    var records = await _context.Products
        //        .Select(x => new ProductDTO()
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            Description = x.Description,
        //            Price = x.Price,
        //            Stock = x.Stock,
        //        }).ToListAsync();

        //    if (requestParams.search != null)
        //        records = await records.Where(x => x.Name.Contains(requestParams.search, StringComparison.OrdinalIgnoreCase)).ToListAsync();

        //    requestParams.recordCount = records.Count;

        //    var data = await Pagination.SortResult(records, requestParams);
        //    return data;
        //}

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var record = await _context.Products
                .Where(x => x.Id == id)
                .Select(x => new ProductDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Stock = x.Stock,
                }).FirstOrDefaultAsync();

            return record!;
        }

        public async Task<ProductDTO> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(product.Id);
        }

        public async Task<ProductDTO> UpdateAsync(int id, Product product)
        {
            var data = await _context.Products.FindAsync(id);
            if (data != null)
            {
                data.Id = id;
                data.Name = product.Name;
                data.Description = product.Description;
                data.Price = product.Price;
                data.Stock = product.Stock;
                data.CreatedDate = product.CreatedDate;
                data.UpdatedDate = DateTime.UtcNow;
                data.IsDeleted = product.IsDeleted;
            }

            _context.Products.Update(data!);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(data!.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}