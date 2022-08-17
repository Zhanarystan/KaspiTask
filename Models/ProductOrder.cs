using System;

namespace KaspiTask.Models
{
    public class ProductOrder
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}