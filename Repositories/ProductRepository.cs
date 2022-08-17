using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.Data;
using KaspiTask.Interfaces;
using KaspiTask.Models;
using Microsoft.EntityFrameworkCore;

namespace KaspiTask.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Product.AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> Get(Guid id)
        {
            return await _context.Product.FindAsync(id);
        }
    }
}