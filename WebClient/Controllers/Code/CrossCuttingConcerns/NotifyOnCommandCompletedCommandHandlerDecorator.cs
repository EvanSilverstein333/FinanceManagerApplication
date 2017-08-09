using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebClient.Controllers.Code.CrossCuttingConcerns
{
    public class NotifyOnCommandCompletedCommandHandlerDecorator<T> : ICommandHandler<T>
    {
        private ICommandHandler<T> _decorated;
        private readonly NotifyCommandCompletedCallback _registrator;
        private readonly RequestResult _requestResult;

        public NotifyOnCommandCompletedCommandHandlerDecorator(ICommandHandler<T> cmdHandler, NotifyCommandCompletedCallback registrator, RequestResult requestResult)
        {
            _decorated = cmdHandler;
            _registrator = registrator;
            _requestResult = requestResult;

        }

        public void Handle(T command)
        {
            
            try
            {
                _decorated.Handle(command);
            }

            finally
            {
                _registrator.ExecuteActions(_requestResult); // callback to controller
                _registrator.Reset();
                
            }

        }



    }
}
