using System;

namespace Common.Models
{
    public class Product : Document
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public Decimal Price { get; set; }

    }
}