using FluentValidation;
using GoTap.MerchantService.Application.Features.Merchants.Commands.CreateMerchant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTap.MerchantService.Application.Validators
{
    public class CreateMerchantValidator : AbstractValidator<CreateMerchantCommand>
    {
        public CreateMerchantValidator()
        {
            RuleFor(x => x.BusinessName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
        }
    }
}
