using System.ComponentModel.DataAnnotations;

namespace Project1.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public int? ParentCategoryId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Level is required.")]
        [Range(1, 3, ErrorMessage = "Level must be between 1 and 3.")]
        public int Level { get; set; }
    }
}