using FabioGusmao.Application.Interfaces;
using FabioGusmao.Domain.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace FabioGusmao.Api.Controllers
{
    public class StockOrderController : ApiController
    {
        private readonly IStockOrderService _ordemRendaVariavelService;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public StockOrderController(IStockOrderService ordemRendaVariavelService)
        {
            _ordemRendaVariavelService = ordemRendaVariavelService;

        }

        [HttpGet]
        public async Task<IEnumerable<StockOrder>> Get()
        {
            try
            {
                return await _ordemRendaVariavelService.GetOrdemRendaVariavels("nogroup");
            }
            catch (Exception ex)
            {
                logger.Error(ex, string.Format("Ocorreu um erro não esperado. Mensagem: {0}", ex.Message));
                throw;
            }
        }

        [HttpGet]
        [Route("api/StockOrder/GroupBy/{groupOption}")]
        public async Task<IEnumerable<StockOrder>> Get(string groupOption)
        {
            try
            {
                return await _ordemRendaVariavelService.GetOrdemRendaVariavels(groupOption);
            }
            catch (Exception ex)
            {
                logger.Error(ex, string.Format("Ocorreu um erro não esperado. Mensagem: {0}", ex.Message));
                throw;
            }
        }
    }
}
