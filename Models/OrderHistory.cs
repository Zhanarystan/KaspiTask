using System;

namespace KaspiTask.Models
{
    public class OrderHistory
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public int StatusId { get; set; }
    }
}