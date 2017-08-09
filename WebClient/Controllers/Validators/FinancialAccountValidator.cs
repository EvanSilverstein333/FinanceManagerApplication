using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FinanceManager.Contract.Dto;

namespace WebClient.Controllers.Validators
{
    public class FinancialAccountValidator : AbstractValidator<FinancialAccountDto>
    {
        public FinancialAccountValidator()
        {
            RuleFor(account => account.FirstName).NotNull().WithMessage("First name is required");
            RuleFor(account => account.LastName).NotNull().WithMessage("Last name is required");

        }

    }
}