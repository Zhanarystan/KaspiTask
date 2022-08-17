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
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private readonly DataContext _context;
        public OrderHistoryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<OrderHistory> Get(Guid orderId, int statusId)
        {
            return await _context.OrderHistory.Where(oh => oh.OrderId == orderId && oh.StatusId == statusId).FirstOrDefaultAsync();
        }
        public async Task<bool> Create(OrderHistory history)
        {
            _context.OrderHistory.Add(history);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(OrderHistory history)
        {
            _context.OrderHistory.Remove(history);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<OrderHistory>> Get(Guid orderId)
        {
            return await _context.OrderHistory.Include(oh => oh.Status).Where(oh => oh.OrderId == orderId).ToListAsync();
        }
    }
}