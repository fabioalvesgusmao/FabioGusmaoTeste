using FabioGusmao.Application.Interfaces;
using FabioGusmao.Application.Services;
using FabioGusmao.DataMock.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NLog.Config;
using System;
using System.IO;

namespace FabioGusmao.Tests
{
    [TestClass]
    public class OrdemRendaVariavelTests
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        [TestMethod]
        public void GetOrdemRendaVariavelTest()
        {
            var serviceProvider = new ServiceCollection()
             .AddLogging()
             .BuildServiceProvider();


            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<OrdemRendaVariavelService>();


            //IOrdemRendaVariavelService service = new OrdemRendaVariavelService(new OrdemRendaVariavelRepository(), logger);

            //service.GetOrdemRendaVariavels();
        }
    }
}
