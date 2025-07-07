using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTap.MerchantService.Application.Features.Merchants.Commands.DeleteMerchant
{
    public record DeleteMerchantCommand(Guid Id) : IRequest;
}
