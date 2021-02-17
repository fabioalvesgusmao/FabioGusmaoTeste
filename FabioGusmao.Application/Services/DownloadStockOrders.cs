using FabioGusmao.Application.Interfaces;
using FabioGusmao.Domain.Model;
using NLog;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabioGusmao.Application.Services
{
    public class DownloadStockOrders : IDownloadStockOrders
    {
        private readonly IStockOrderService _ordemRendaVariavelService;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public DownloadStockOrders(IStockOrderService ordemRendaVariavelService)
        {
            _ordemRendaVariavelService = ordemRendaVariavelService;
        }

        public async Task<MemoryStream> GenerateFile(string groupBy, string fileFormat)
        {
            try
            {
                logger.Trace("Iniciando processo de gerar arquivo para download.");

                var stockOrders = await _ordemRendaVariavelService.GetOrdemRendaVariavels(groupBy);

                MemoryStream memoryStream = new MemoryStream();

                if (fileFormat.ToLower() == "csv")
                {
                    memoryStream = GenerateCsvFile(stockOrders.ToList());
                }
                else if (fileFormat.ToLower() == "xlsx")
                {
                    memoryStream = GenerateExcelFile(stockOrders.ToList());
                }

                logger.Trace("Finalizado processo de gerar arquivo para download");

                return memoryStream;
            }
            catch (Exception ex)
            {
                logger.Error(ex, string.Format("Ocorreu um erro não esperado. Mensagem: {0}", ex.Message));
                throw;
            }
        }

        private MemoryStream GenerateCsvFile(List<StockOrder> stockOrders)
        {
            try
            {
                logger.Trace("Iniciando tratamento arquivo CSV.");

                MemoryStream memoryStream = new MemoryStream();

                byte[] bytes;
                var stockOrdersCsv = Infra.FileUtils.CsvConverter.SaveToCsv<StockOrder>(stockOrders.ToList());
                bytes = Encoding.ASCII.GetBytes(stockOrdersCsv);
                memoryStream = new MemoryStream(bytes);

                return memoryStream;
            }
            catch (Exception ex)
            {
                logger.Error(ex, string.Format("Ocorreu um erro não esperado. Mensagem: {0}", ex.Message));
                throw;
            }
        }

        private MemoryStream GenerateExcelFile(List<StockOrder> stockOrders)
        {
            try
            {
                logger.Trace("Iniciando tratamento arquivo EXCEL.");

                MemoryStream memoryStream = new MemoryStream();

                using (MemoryStream tempStream = new MemoryStream())
                {
                    XSSFWorkbook workbook = new XSSFWorkbook();

                    ISheet Sheet = workbook.CreateSheet("Ordens");

                    IRow HeaderRow = Sheet.CreateRow(0);

                    CreateCell(HeaderRow, 0, "Id");
                    CreateCell(HeaderRow, 1, "DateTime");
                    CreateCell(HeaderRow, 2, "Tipo Operação");
                    CreateCell(HeaderRow, 3, "Ativo");
                    CreateCell(HeaderRow, 4, "Quantidade");
                    CreateCell(HeaderRow, 5, "Preço");
                    CreateCell(HeaderRow, 6, "Conta");

                    int rowNum = 1;

                    foreach (var stockOrder in stockOrders)
                    {
                        IRow row = Sheet.CreateRow(rowNum);
                        ICell cell;

                        if (stockOrder.Id.HasValue)
                        {
                            cell = row.CreateCell(0);
                            cell.SetCellValue(stockOrder.Id.Value);
                        }

                        if (stockOrder.DateTime.HasValue)
                        {
                            cell = row.CreateCell(1);
                            cell.SetCellValue(stockOrder.DateTime.Value);
                        }

                        cell = row.CreateCell(2);
                        cell.SetCellValue(stockOrder.OperationType);

                        cell = row.CreateCell(3);
                        cell.SetCellValue(stockOrder.Ticker);

                        cell = row.CreateCell(4);
                        cell.SetCellValue(stockOrder.Quantity);

                        cell = row.CreateCell(5);
                        cell.SetCellValue(decimal.ToDouble(stockOrder.Price));

                        if (stockOrder.Account.HasValue)
                        {
                            cell = row.CreateCell(6);
                            cell.SetCellValue(stockOrder.Account.Value);
                        }

                        rowNum++;
                    }

                    workbook.Write(tempStream);
                    var byteArray = tempStream.ToArray();
                    memoryStream.Write(byteArray, 0, byteArray.Length);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    return memoryStream;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, string.Format("Ocorreu um erro não esperado. Mensagem: {0}", ex.Message));
                throw;
            }
        }

        private void CreateCell(IRow CurrentRow, int CellIndex, string Value)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
        }
    }
}
