using System;
using KaspiTask.Models;

namespace KaspiTask.DTOs 
{
    public class OrderHistoryDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
    }
}