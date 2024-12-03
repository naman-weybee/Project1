using Project1.DTOs;
using Project1.Models;

namespace Project1.AutoMapper
{
    public class Mapper
    {
        public ProductDTO ProductMapper(Product product)
        {
            try
            {
                var record = new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Stock = product.Stock
                };

                if (record != null)
                    return record;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public CategoryDTO CategoryMapper(Category product)
        {
            try
            {
                var record = new CategoryDTO
                {
                    Id = product.Id,
                    ParentCategoryId = product.ParentCategoryId,
                    Name = product.Name,
                    Level = product.Level
                };

                if (record != null)
                    return record;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}