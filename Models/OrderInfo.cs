using System;

namespace KaspiTask.Models
{
    public class OrderInfo
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string CardNumber { get; set; }
        public int TotalSum { get; set; }
    }
}