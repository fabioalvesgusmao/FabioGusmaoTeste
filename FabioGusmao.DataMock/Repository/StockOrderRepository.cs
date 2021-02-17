using FabioGusmao.DataMock.Entities;
using FabioGusmao.Domain.Interfaces;
using FabioGusmao.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace FabioGusmao.DataMock.Repository
{
    public class StockOrderRepository : IOrdemRendaVariavelRepository
    {
        public async Task<IEnumerable<StockOrder>> GetOrdemRendaVariavels()
        {
            if (!File.Exists(Path.Combine(Path.GetTempPath(), "ordenslist.json")))
            {
                GenerateJsonFile();
            }

            var stringFile = File.ReadAllText(Path.Combine(Path.GetTempPath(), "ordenslist.json"));

            var result = JsonConvert.DeserializeObject<IEnumerable<StockOrderJson>>(stringFile);

            ConcurrentBag<StockOrder> stockOrders = new ConcurrentBag<StockOrder>();

            Parallel.ForEach(result, (item) =>
            {
                stockOrders.Add(new StockOrder()
                {
                    Account = item.Conta,
                    DateTime = item.DateTime,
                    Id = item.Id,
                    OperationType = item.TipoOperacao,
                    Price = item.Preco,
                    Quantity = item.Quantidade,
                    Ticker = item.Ativo
                });
            });

            return stockOrders;
        }

        private void GenerateJsonFile()
        {
            List<StockOrderJson> stockOrderJsons = new List<StockOrderJson>();
            List<string> ativos = new List<string>() { "PETR4", "ROMI3", "VALE3", "BPAN4", "ITSA4", "EMBR3", "BRDT3", "PRIO3", "RAIL3", "HFER3" };
            List<string> naturezas = new List<string>() { "C", "V" };

            Random rnd = new Random();

            for (int i = 0; i < 20000; i++)
            {
                stockOrderJsons.Add(new StockOrderJson()
                {
                    Ativo = ativos[rnd.Next(0, 10)],
                    Conta = rnd.Next(4000, 4100),
                    DateTime = DateTime.Now,
                    Id = i + 100,
                    Preco = decimal.Parse(rnd.Next(1, 80).ToString() + CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator + rnd.Next(0, 100).ToString()),
                    Quantidade = 100 * rnd.Next(1, 21),
                    TipoOperacao = naturezas[rnd.Next(0, 2)]
                }); ;
            }

            var json = JsonConvert.SerializeObject(stockOrderJsons);
            File.WriteAllText(Path.Combine(Path.GetTempPath(), "ordenslist.json"), json);
        }


    }
}
