using FabioGusmao.Application.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FabioGusmao.Api.Controllers
{
    public class StockOrderDownloadController : ApiController
    {
        private readonly IDownloadStockOrders _downloadStockOrders;

        public StockOrderDownloadController(IDownloadStockOrders downloadStockOrders)
        {
            _downloadStockOrders = downloadStockOrders;
        }

        // GET api/values
        [HttpGet]
        [Route("api/StockOrderDownload/{groupBy}/{fileFormat}")]
        public async Task<HttpResponseMessage> Get(string groupBy, string fileFormat)
        {
            var memoryStream = await _downloadStockOrders.GenerateFile(groupBy, fileFormat);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(memoryStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "listaordens" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + fileFormat;
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            return httpResponseMessage;
        }

        [HttpGet]
        [Route("api/StockOrderDownload/{fileFormat}")]
        public async Task<HttpResponseMessage> Get(string fileFormat)
        {
            var memoryStream = await _downloadStockOrders.GenerateFile(string.Empty, fileFormat);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(memoryStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "listaordens" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + fileFormat;
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }
    }
}
