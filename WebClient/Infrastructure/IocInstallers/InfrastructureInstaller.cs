using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using WebClient.Infrastructure.Abstractions;
using FluentValidation;
using System.Reflection;
using FluentValidation.Mvc;
using WebClient.Controllers.Code;
using log4net;
using WebClient.Controllers.Code.CrossCuttingConcerns;
//using log4net;
//using Controllers.Code;
//using Controllers.Code.CrossCuttingConcerns;
//using Controllers.Controllers;
//using Controllers.InternalMessages;
//using Infrastructure.Configuration.Services;

namespace WebClient.Infrastructure.IocInstallers
{
    static class InfrastructureInstaller
    {

        public static void RegisterServices(Container _simpleContainer)
        {
            _simpleContainer.RegisterMvcIntegratedFilterProvider();
            _simpleContainer.RegisterSingleton<ILog>(Bootstrapper.Logger);
            _simpleContainer.Register<ILogger, Logger>();
            _simpleContainer.RegisterSingleton<ICommandProcessor>(new CommandProcessor());
            _simpleContainer.RegisterSingleton<IQueryProcessor>(new QueryProcessor());
            _simpleContainer.Register(typeof(ICommandHandler<>), typeof(WcfServiceCommandHandlerProxy<>));
            _simpleContainer.Register(typeof(IQueryHandler<,>), typeof(WcfServiceQueryHandlerProxy<,>));
            _simpleContainer.RegisterSingleton<FinanceManagerMessageCallback>();

            _simpleContainer.Register<IValidatorFactory, ApplicationValidatorFactory>(Lifestyle.Singleton);
            FluentValidationModelValidatorProvider.Configure(provider =>{
                provider.ValidatorFactory = new ApplicationValidatorFactory();
                provider.AddImplicitRequiredValidator = false;
            });

        }
    }
}
