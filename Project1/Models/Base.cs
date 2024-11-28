namespace Project1.Models
{
    public class Base
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; }
    }
}