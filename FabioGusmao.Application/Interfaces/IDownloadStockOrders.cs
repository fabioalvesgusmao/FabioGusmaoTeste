using System.IO;
using System.Threading.Tasks;

namespace FabioGusmao.Application.Interfaces
{
    public interface IDownloadStockOrders
    {
        Task<MemoryStream> GenerateFile(string groupBy, string fileFormat);
    }
}
