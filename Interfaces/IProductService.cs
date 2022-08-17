using System.Collections.Generic;
using System.Threading.Tasks;
using KaspiTask.Core;
using KaspiTask.Models;

namespace KaspiTask.Interfaces
{
    public interface IProductService
    {
         Task<Result<IEnumerable<Product>>> Get();
    }
}