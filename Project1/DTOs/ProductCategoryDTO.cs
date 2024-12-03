using System.ComponentModel.DataAnnotations;

namespace Project1.DTOs
{
    public class ProductCategoryDTO
    {
        [Required(ErrorMessage = "Product Id is required.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Category Id is required.")]
        public int CategoryId { get; set; }
    }
}