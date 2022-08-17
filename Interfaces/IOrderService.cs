using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.Core;
using KaspiTask.DTOs;
using KaspiTask.Models;

namespace KaspiTask.Interfaces
{
    public interface IOrderService
    {
        Task<Result<IEnumerable<OrderDto>>> Get();
        Task<Result<OrderDto>> Get(Guid id);
        Task<Result<OrderDto>> GetCurrent();
        Task<Result<OrderDto>> Create();
        Task<Result<Order>> Delete(Guid id);
        Task<Result<OrderDto>> Pay(CreateOrderInfoDto dto);
        Task<Result<IEnumerable<ProductOrderDto>>> GetProducts(Guid orderId);
        Task<Result<IEnumerable<OrderHistoryDto>>> GetHistory(Guid orderId);
        Task<Result<OrderDto>> Complete(Guid id);
    }
}