using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FinanceManager.Contract.Commands;

namespace WebClient.Controllers.Validators
{
    public class UpdateFinancialTransactionCommandValidator : AbstractValidator<UpdateFinancialTransactionCommand>
    {
        public UpdateFinancialTransactionCommandValidator()
        {
            RuleFor(cmd => cmd.Transaction).SetValidator(new FinancialTransactionValidator());
        }
    }
}