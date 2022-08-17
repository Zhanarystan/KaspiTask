using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.Models;

namespace KaspiTask.Interfaces
{
    public interface ITransactionService
    {
        Task<bool> Pay(Order order, OrderHistory history, OrderInfo info);
    }
}