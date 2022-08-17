using System;
using KaspiTask.Models;

namespace KaspiTask.DTOs
{
    public class CreateProductOrderDto
    {
        public int Amount { get; set; }
        public int Price { get; set; }
        public Guid ProductId { get; set; }
    }
}