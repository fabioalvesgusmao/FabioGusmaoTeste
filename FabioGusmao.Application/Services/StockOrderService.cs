using FabioGusmao.Application.Interfaces;
using FabioGusmao.Domain.Interfaces;
using FabioGusmao.Domain.Model;
using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace FabioGusmao.Application.Services
{
    public class StockOrderService : IStockOrderService
    {
        private readonly IOrdemRendaVariavelRepository _ordemRendaVariavelRepository;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public StockOrderService(IOrdemRendaVariavelRepository ordemRendaVariavelRepository)
        {
            _ordemRendaVariavelRepository = ordemRendaVariavelRepository;
        }

        public async Task<IEnumerable<StockOrder>> GetOrdemRendaVariavels(string groupBy)
        {
            try
            {
                logger.Trace("Iniciando processo de consulta das ordens.");

                var result = await GetFromCache(groupBy, async () =>
                {
                    logger.Trace("Ordens não encontradas no cache.");

                    switch (groupBy.ToLower())
                    {
                        case "fixed":
                            return await GetGroupedOrders(true, true, true);
                        case "ticker":
                            return await GetGroupedOrders(false, true, false);
                        case "operationtype":
                            return await GetGroupedOrders(false, false, true);
                        case "account":
                            return await GetGroupedOrders(true, false, false);
                        default:
                            return await _ordemRendaVariavelRepository.GetOrdemRendaVariavels();
                    }
                });

                logger.Trace("Consulta finalizada.");

                return result;
            }
            catch(Exception ex)
            {
                logger.Error(ex, string.Format("Ocorreu um erro não esperado. Mensagem: {0}", ex.Message));
                throw;
            }
        }

        private async Task<IEnumerable<StockOrder>> GetGroupedOrders(bool byAccount, bool byTicker, bool byOperationType)
        {
            var result = await _ordemRendaVariavelRepository.GetOrdemRendaVariavels();

            ConcurrentBag<StockOrder> list = new ConcurrentBag<StockOrder>();

            var groupResult = result.GroupBy(x => new { Conta = byAccount ? x.Account : null, Ativo = byTicker ? x.Ticker : null, TipoOperacao = byOperationType ? x.OperationType : null });

            Parallel.ForEach(groupResult, (item) =>
            {
                list.Add(new StockOrder()
                {
                    Ticker = item.Key.Ativo,
                    Account = item.Key.Conta,
                    DateTime = null,
                    Id = null,
                    Price = item.Sum(x => x.Quantity * x.Price) / item.Sum(x => x.Quantity),
                    Quantity = item.Sum(x => x.Quantity),
                    OperationType = item.Key.TipoOperacao
                });
            });

            return list.ToList();
        }

        private async Task<TEntity> GetFromCache<TEntity>(string key, Func<Task<TEntity>> valueFactory) where TEntity : class
        {
            ObjectCache cache = MemoryCache.Default;
            
            var newValue = new Lazy<Task<TEntity>>(valueFactory);
            CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30) };
            
            var value = cache.Get(key) as TEntity;

            if (value != null)
            {
                logger.Trace("Ordens encontradas no cache.");
                return value;
            }
            else
            {
                var valeucache = await newValue.Value;
                cache.Add(key, valeucache, policy);

                return valeucache;
            }
        }
    }
}
