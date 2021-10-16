using System;

namespace Common.Models
{
    public class Order : Document
    {
        public Guid CustomerId { get; set; }
        public Decimal TotalPrice { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        
        
    }
}