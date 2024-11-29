﻿namespace Project1.Models
{
    public class Product : Base
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}