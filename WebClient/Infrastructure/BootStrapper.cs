using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using WebClient.Infrastructure.IocInstallers;
using FinanceManager.Contract.Commands;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using log4net;

namespace WebClient.Infrastructure
{
    public static class Bootstrapper
    {
        public static readonly Container Container;
        public static Type[] AllContractTypes { get; private set; }
        public static readonly ILog Logger;


        static Bootstrapper()
        {
            Logger = log4net.LogManager.GetLogger("RollingFileLogger");
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            InfrastructureInstaller.RegisterServices(container);
            ControllersInstaller.RegisterServices(container);
            GetContractTypes();

            container.Verify();
            Container = container;

        }

        private static void GetContractTypes()
        {
            var allTypesInContractAssembly = typeof(ICommand).Assembly.GetExportedTypes();
            var contractTypes = allTypesInContractAssembly.Where(t => t.IsClass).ToArray();
            AllContractTypes = contractTypes;
        }

    }
}
