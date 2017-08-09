using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace WebClient.Infrastructure.Abstractions
{
    public class ApplicationValidatorFactory : IValidatorFactory
    {
        public IValidator<T> GetValidator<T>()
        {
            return Bootstrapper.Container.GetInstance<IValidator<T>>();
        }

        public IValidator GetValidator(Type type)
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(type);
            var validator = Bootstrapper.Container.GetInstance(validatorType);
            return (IValidator)validator;
        }
    }
}