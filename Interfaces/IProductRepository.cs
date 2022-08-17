using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.Models;

namespace KaspiTask.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(Guid id);
        Task<bool> Exists(Guid id);
    }
}