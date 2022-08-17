using System;
using KaspiTask.Models;

namespace KaspiTask.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public OrderInfo Info { get; set; }
        public OrderStatus Status { get; set; }
    }
}