using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace WebClient.Controllers.Code.CrossCuttingConcerns
{
    public class ValidationCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private ICommandHandler<TCommand> _decorated;
        private IValidator _validator;

        public ValidationCommandHandlerDecorator(IValidator<TCommand> validator, ICommandHandler<TCommand> cmdHandler)
        {
            _decorated = cmdHandler;
            _validator = validator;
        }
        
        public void Handle(TCommand command)
        {
            var validationResult = _validator.Validate(command);
            if (!validationResult.IsValid)
            {
                var msg = BuildErrorMessage(validationResult.Errors);
                throw new ValidationException(msg, validationResult.Errors);
            }
            else { _decorated.Handle(command); }
        }

        private string BuildErrorMessage(IEnumerable<ValidationFailure> errors)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var error in errors) { sb.AppendLine(error.ErrorMessage); }
            return sb.ToString();
            
        }
    }
}
