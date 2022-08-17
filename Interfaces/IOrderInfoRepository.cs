using System.Threading.Tasks;
using KaspiTask.Models;

namespace KaspiTask.Interfaces
{
    public interface IOrderInfoRepository
    {
      Task<bool> Create(OrderInfo info);
      Task<bool> Delete(OrderInfo info);
    }
}