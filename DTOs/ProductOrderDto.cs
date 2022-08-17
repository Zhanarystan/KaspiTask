using System;
using KaspiTask.Models;

namespace KaspiTask.DTOs
{
    public class ProductOrderDto
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public Product Product { get; set; }
        public Guid OrderId { get; set; }
    }
}