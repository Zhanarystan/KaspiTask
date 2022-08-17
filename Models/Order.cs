using System;
using System.Collections.Generic;

namespace KaspiTask.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public static int OrderNumber { get; set; } = 1;
        public string Name { get; set; }
        public OrderInfo Info { get; set; }
        public Guid? InfoId { get; set; }
        public OrderStatus Status { get; set; }
        public int? StatusId { get; set; }
        public ICollection<OrderHistory> History { get; set; }
        public ICollection<ProductOrder> Products { get; set; }

        public void GenerateName()
        {
            Name = $"ЗАКАЗ-{DateTime.Now.Year}-{OrderNumber.ToString("0000")}";
        }
    }
}