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
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Order order)
        {
            _context.Order.Add(order);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Order order)
        {
            _context.Order.Remove(order);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Order.AnyAsync(o => o.Id == id);
        }

        public async Task<Order> Get(Guid id)
        {
            return await _context.Order
                .Include(o => o.Info)
                .Include(o => o.Status)
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _context.Order
                .Include(o => o.Info)
                .Include(o => o.Status)
                .ToListAsync();
        }

        public async Task<Order> GetCurrent()
        {
            return await _context.Order
                .Include(o => o.Info)
                .Include(o => o.Status)
                .Where(o => o.StatusId == (int)OrderStatusEnum.Forming)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Order order)
        {
            _context.Order.Update(order);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}