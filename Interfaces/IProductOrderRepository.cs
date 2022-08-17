using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.Models;

namespace KaspiTask.Interfaces
{
    public interface IProductOrderRepository
    {
        Task<bool> Create(ProductOrder productOrder);
        Task<int> CreateRange(List<ProductOrder> productOrderList);
        Task<bool> Update(ProductOrder productOrder);
        Task<bool> Delete(ProductOrder productOrder);
        Task<IEnumerable<ProductOrder>> Get(Guid orderId);
        Task<ProductOrder> Get(Guid orderId, Guid productId);
    }
}