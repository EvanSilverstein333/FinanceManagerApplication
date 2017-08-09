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

            _simpleContainer.Register<IValidatorFactory, ApplicationValidatorFactory>(Lifestyle.Singleton);
            FluentValidationModelValidatorProvider.Configure(provider =>{
                provider.ValidatorFactory = new ApplicationValidatorFactory();
                provider.AddImplicitRequiredValidator = false;
            });

                //_simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(NotifyOnRequestCompletedCommandHandlerDecorator<>));
                //_simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(FromWcfFaultTranslatorCommandHandlerDecorator<>));
                //_simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(ErrorHandlingCommandHandlerDecorator<>));


                //_simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(NotifyOnRequestIssuedCommandHandlerDecorator<>));
                //_simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(NotifyOnRequestCompletedCommandHandlerDecorator<>));
                //_simpleContainer.Register<IDomainEventStore, DomainEventStore>();
                //_simpleContainer.Register<IDomainEventProcessor, DomainEventProcessor>();
                //_simpleContainer.Register<IExternalMessagePublisher, ExternalMessagePublisher>();

                //_simpleContainer.RegisterCollection(typeof(IEventHandler<>), AppDomain.CurrentDomain.GetAssemblies());

            }
    }
}
