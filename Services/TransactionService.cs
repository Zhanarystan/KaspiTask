using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.Data;
using KaspiTask.Interfaces;
using KaspiTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KaspiTask.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly DataContext _context;
        private readonly ILogger<TransactionService> _logger;
        public TransactionService(DataContext context, ILogger<TransactionService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> Pay(Order order, OrderHistory history, OrderInfo info)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _logger.LogWarning($"UPDATE Order SET StatusId={order.StatusId} WHERE Id={order.Id};");
                    _context.Order.Update(order);
                    _context.OrderHistory.Add(history);
                    _context.OrderInfo.Add(info);
                    // _context.Database.ExecuteSqlInterpolated($"UPDATE Order SET StatusId={order.StatusId} WHERE Id={order.Id};");
                    
                    // _context.Database.ExecuteSqlInterpolated
                    // (@$"INSERT INTO OrderHistory (CreatedAt, OrderId, StatusId) 
                    //     VALUES ({history.CreatedAt}, {history.OrderId}, {history.StatusId});");
                    
                    // _context.Database.ExecuteSqlInterpolated
                    // (@$"INSERT INTO OrderInfo (Address, CardNumber, TotalSum) 
                    //     VALUES ({info.Address}, {info.CardNumber}, {info.TotalSum})");
                    
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}