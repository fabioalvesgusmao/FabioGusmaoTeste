[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FabioGusmao.Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FabioGusmao.Api.App_Start.NinjectWebCommon), "Stop")]

namespace FabioGusmao.Api.App_Start
{
    using FabioGusmao.Application.Interfaces;
    using FabioGusmao.Application.Services;
    using FabioGusmao.DataMock.Repository;
    using FabioGusmao.Domain.Interfaces;
    //using Microsoft.Extensions.Logging;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    //using Ninject.Extensions.Logging;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;
    using WebApiContrib.IoC.Ninject;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                //kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                //kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                //RegisterServices(kernel);
                //return kernel;
                //RegisterServices(kernel);
                //GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                //return kernel;

                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                //===Add this line===
                System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
                //===================
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            //ILoggerFactory loggerFactory = kernel.Get<ILoggerFactory>();
            //ILogger logger = loggerFactory.GetCurrentClassLogger();
            //ILogger logger = loggerFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            //ILogger logger = loggerFactory.GetLogger(GetType());

            //var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            //kernel.Bind<ILogger>()
            //   .ToMethod(context =>
            //   {
            //       var categoryName = context?.Request?.ParentRequest?.Service.FullName ?? "Unspecified";
            //       return loggerFactory.CreateLogger(categoryName);
            //   });

            kernel.Bind<IStockOrderService>().To<StockOrderService>();
            kernel.Bind<IDownloadStockOrders>().To<DownloadStockOrders>();
            kernel.Bind<IOrdemRendaVariavelRepository>().To<StockOrderRepository>();
        }
    }
}