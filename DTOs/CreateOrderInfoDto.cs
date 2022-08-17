using System.Collections.Generic;

namespace KaspiTask.DTOs
{
    public class CreateOrderInfoDto
    {
        public string Address { get; set; }
        public string CardNumber { get; set; }
        public int TotalCost { get; set; }
        public List<CreateProductOrderDto> Products { get; set; }
    }
}