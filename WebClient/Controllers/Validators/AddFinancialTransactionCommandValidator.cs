using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FinanceManager.Contract.Commands;

namespace WebClient.Controllers.Validators
{
    public class AddFinancialTransactionCommandValidator: AbstractValidator<AddFinancialTransactionCommand>
    {
        public AddFinancialTransactionCommandValidator()
        {
            RuleFor(cmd => cmd.Transaction).SetValidator(new FinancialTransactionValidator());
        }
    }
}