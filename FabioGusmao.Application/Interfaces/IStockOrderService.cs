using FabioGusmao.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabioGusmao.Application.Interfaces
{
    public interface IStockOrderService
    {
        Task<IEnumerable<StockOrder>> GetOrdemRendaVariavels(string groupBy);
    }
}
