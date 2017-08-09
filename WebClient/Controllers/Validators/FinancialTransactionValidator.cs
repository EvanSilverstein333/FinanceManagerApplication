using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FinanceManager.Contract.Dto;

namespace WebClient.Controllers.Validators
{
    public class FinancialTransactionValidator : AbstractValidator<FinancialTransactionDto>
    {
        public FinancialTransactionValidator()
        {
            RuleFor(transaction => transaction.Date).NotNull().WithMessage("Date is required");
            RuleFor(transaction => transaction.Money.Currency).NotNull().WithMessage("Currency is required");

        }

    }
}