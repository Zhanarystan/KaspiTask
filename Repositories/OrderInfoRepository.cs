using System.Threading.Tasks;
using KaspiTask.Data;
using KaspiTask.Interfaces;
using KaspiTask.Models;

namespace KaspiTask.Repositories
{
    public class OrderInfoRepository : IOrderInfoRepository
    {
        private readonly DataContext _context;
        public OrderInfoRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(OrderInfo info)
        {
            _context.OrderInfo.Add(info);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(OrderInfo info)
        {
            _context.OrderInfo.Remove(info);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}