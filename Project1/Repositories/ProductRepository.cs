using Project1.Configurations;
using Project1.Models;

namespace Project1.Repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllAsync()
        {
            //Filter and Sorting is Pending
            return _context.Products.ToList();
        }

        public Product GetByIdAsync(int id)
        {
            return _context.Products.Find(id);
        }

        public async void AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async void UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async void DeleteAsync(int id)
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