using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FinanceManager.Contract.Commands;

namespace WebClient.Controllers.Validators
{
    public class UpdateFinancialAccountCommandValidator : AbstractValidator<UpdateFinancialAccountCommand>
    {
        public UpdateFinancialAccountCommandValidator()
        {
            RuleFor(cmd => cmd.Account).SetValidator(new FinancialAccountValidator());
        }
    }
}