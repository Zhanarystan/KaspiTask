using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaspiTask.Data;
using KaspiTask.Interfaces;
using KaspiTask.Models;
using Microsoft.EntityFrameworkCore;

namespace KaspiTask.Repositories
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private readonly DataContext _context;
        public ProductOrderRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(ProductOrder productOrder)
        {
            _context.ProductOrder.Add(productOrder);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> CreateRange(List<ProductOrder> productOrderList)
        {
            _context.ProductOrder.AddRange(productOrderList);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(ProductOrder productOrder)
        {
            _context.ProductOrder.Remove(productOrder);
            return await _context.SaveChangesAsync() > 0; 
        }

        public async Task<ProductOrder> Get(Guid orderId, Guid productId)
        {
            return await _context.ProductOrder
                .Include(po => po.Product)
                .Where(po => po.OrderId == orderId && po.ProductId == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductOrder>> Get(Guid orderId)
        {
            return await _context.ProductOrder
                .Include(po => po.Product)
                .Where(po => po.OrderId == orderId )
                .ToListAsync();
        }

        public async Task<bool> Update(ProductOrder productOrder)
        {
            _context.ProductOrder.Update(productOrder);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}