using FluentValidation;
using GoTap.MerchantService.Application.Features.Merchants.Commands.CreateMerchant;
using GoTap.MerchantService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTap.MerchantService.Application.Validators
{
    public class CreateMerchantValidator : AbstractValidator<CreateMerchantCommand>
    {
        public CreateMerchantValidator(ICountryValidatorService countryValidator)
        {
            RuleFor(x => x.BusinessName)
                .NotEmpty().WithMessage("Business name is required.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.")
                .WithMessage("Invalid country provided.");
        }
    }
}
