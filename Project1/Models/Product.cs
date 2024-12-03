using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class Product : Base
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Length(1, 500)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}