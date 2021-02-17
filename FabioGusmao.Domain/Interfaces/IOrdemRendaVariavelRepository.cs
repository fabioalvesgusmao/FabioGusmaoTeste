using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FabioGusmao.Domain.Model;

namespace FabioGusmao.Domain.Interfaces
{
    public interface IOrdemRendaVariavelRepository
    {
        Task<IEnumerable<StockOrder>> GetOrdemRendaVariavels();
    }
}
