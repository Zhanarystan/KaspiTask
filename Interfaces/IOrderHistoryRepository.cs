using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.Models;

namespace KaspiTask.Interfaces
{
    public interface IOrderHistoryRepository
    {
        Task<OrderHistory> Get(Guid orderId, int statusId);
        Task<bool> Create(OrderHistory history);
        Task<bool> Delete(OrderHistory history);
        Task<IEnumerable<OrderHistory>> Get(Guid orderId);
    }
}