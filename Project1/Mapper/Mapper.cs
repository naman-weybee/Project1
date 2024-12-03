using Project1.DTOs;
using Project1.Models;

namespace Project1.AutoMapper
{
    public class Mapper
    {
        public ProductDTO ProductMapper(Product item)
        {
            try
            {
                var record = new ProductDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Stock = item.Stock
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

        public CategoryDTO CategoryMapper(Category item)
        {
            try
            {
                var record = new CategoryDTO
                {
                    Id = item.Id,
                    ParentCategoryId = item.ParentCategoryId,
                    Name = item.Name,
                    Level = item.Level
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

        public ProductCategoryDTO ProductCategoryMapper(ProductCategory item)
        {
            try
            {
                var record = new ProductCategoryDTO
                {
                    ProductId = item.ProductId,
                    CategoryId = item.CategoryId
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