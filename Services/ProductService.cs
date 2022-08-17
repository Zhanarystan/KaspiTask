using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.Core;
using KaspiTask.Interfaces;
using KaspiTask.Models;

namespace KaspiTask.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result<IEnumerable<Product>>> Get()
        {
            return Result<IEnumerable<Product>>.Success(await _productRepository.Get());
        }
    }
}