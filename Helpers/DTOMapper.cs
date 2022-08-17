using System.Collections.Generic;
using KaspiTask.DTOs;
using KaspiTask.Models;

namespace KaspiTask.Helpers
{
    public static class DTOMapper
    {
        public static ProductOrderDto MapProductOrder(ProductOrder productOrder)
        {
            return new ProductOrderDto
            {
                Id = productOrder.Id,
                Amount = productOrder.Amount,
                Price = productOrder.Price,
                Product = productOrder.Product,
                OrderId = productOrder.OrderId
            };
        }

        public static List<ProductOrderDto> MapProductOrderList(IEnumerable<ProductOrder> productOrders)
        {
            var list = new List<ProductOrderDto>();
            foreach(var productOrder in productOrders)
            {
                list.Add(MapProductOrder(productOrder));
            }
            return list;
        }

        public static OrderDto MapOrder(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                Name = order.Name,
                Info = order.Info,
                Status = order.Status,
            };
        }

        public static List<OrderDto> MapOrderList(IEnumerable<Order> orders) 
        {
            var list = new List<OrderDto>();
            foreach(var order in orders)
            {
                list.Add(MapOrder(order));
            }
            return list;
        }

        public static OrderHistoryDto MapOrderHistory(OrderHistory history)
        {
            return new OrderHistoryDto
            {
                Id = history.Id,
                CreatedAt = history.CreatedAt,
                Status = history.Status
            };
        }

        public static List<OrderHistoryDto> MapOrderHistoryList(IEnumerable<OrderHistory> histories) 
        {
            var list = new List<OrderHistoryDto>();
            foreach(var history in histories)
            {
                list.Add(MapOrderHistory(history));
            }
            return list;
        }

        public static OrderInfo MapOrderInfoFromDto(CreateOrderInfoDto dto)
        {
            return new OrderInfo 
            {
                Address = dto.Address,
                CardNumber = dto.CardNumber,
                TotalSum = dto.TotalCost
            };
        }
    }
}