using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Data;
using Shared;

namespace WebClient.Controllers.Code.CrossCuttingConcerns
{
    public class ErrorHandlingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private ICommandHandler<TCommand> _decorated;
        private ILogger _logger;
        private RequestResult _requestResult;

        public ErrorHandlingCommandHandlerDecorator(ICommandHandler<TCommand> cmdHandler, ILogger logger, RequestResult requestResult)
        {
            _decorated = cmdHandler;
            _logger = logger;
            _requestResult = requestResult;
        }
        
        public void Handle(TCommand command)
        {
            _requestResult.Succeeded = false;
            try
            {
                _logger.Info(string.Format("{0} executed", command.GetType().Name));
                _decorated.Handle(command);
                _requestResult.Succeeded = true;
            }
            catch(ValidationException e)
            { 
                _logger.Error("Command failed due to validation errors", e);
                _requestResult.MessageContents = new MessageContents(e.Message,"ValidationError");
            }
            catch(TimeoutException e)
            {
                _logger.Error("Command failed due to a timeout error", e);
                _requestResult.MessageContents = new MessageContents(e.Message, "TimeoutError");

            }

            catch (OptimisticConcurrencyException e)
            {
                _logger.Error("Command failed due to a concurrency error", e);
                _requestResult.MessageContents = new MessageContents(e.Message, "ConcurrencyError");
            }


        }

    }
}
