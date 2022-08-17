using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.Models;

namespace KaspiTask.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> Get();
        Task<Order> GetCurrent();
        Task<Order> Get(Guid id);
        Task<bool> Create(Order order);
        Task<bool> Update(Order order);
        Task<bool> Delete(Order order);
        Task<bool> Exists(Guid id);
    }
}