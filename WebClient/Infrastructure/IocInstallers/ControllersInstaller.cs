using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using WebClient.Controllers;
//using Controllers.Controllers;
//using Controllers.InternalMessages;
//using Controllers.Code.ExternalEventHandlers;
//using Controllers.Code.CrossCuttingConcerns;
using System.Web.Mvc;
using System.Reflection;
using FluentValidation;
using WebClient.Controllers.Validators;
using WebClient.Controllers.Code;
using WebClient.Controllers.Code.CrossCuttingConcerns;

namespace WebClient.Infrastructure.IocInstallers
{
    static class ControllersInstaller
    {
        public static void RegisterServices(Container _simpleContainer)
        {
            //controllers
            _simpleContainer.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            _simpleContainer.Register<NotifyCommandCompletedCallback>(Lifestyle.Scoped);
            _simpleContainer.Register<INotifyCommandCompletedCallback>(() => _simpleContainer.GetInstance<NotifyCommandCompletedCallback>());
            _simpleContainer.Register<RequestResult>(Lifestyle.Scoped);

            //Validators
            _simpleContainer.Register(typeof(IValidator<>), AppDomain.CurrentDomain.GetAssemblies(), Lifestyle.Singleton);
            _simpleContainer.RegisterConditional(typeof(IValidator<>), typeof(EmptyValidator<>), Lifestyle.Singleton,
            c => !c.Handled);

            //CrossCuttingConcerns
            _simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));
            _simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(FromWcfFaultTranslatorCommandHandlerDecorator<>));
            _simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(ErrorHandlingCommandHandlerDecorator<>));
            _simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(NotifyOnCommandCompletedCommandHandlerDecorator<>));



        }


    }
}
