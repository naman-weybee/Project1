using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class Category : Base
    {
        public int Id { get; set; }

        [ForeignKey("ParentCategoryId")]
        [ValueRange(1, 2)]
        public int? ParentCategoryId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [ValueRange(1, 3)]
        public int Level { get; set; }

        public virtual ICollection<Category> ChildCategories { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}