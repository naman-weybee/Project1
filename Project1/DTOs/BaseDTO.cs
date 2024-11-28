namespace Project1.DTOs
{
    public class BaseDTO
    {
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}