using GoTap.MerchantService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTap.MerchantService.Application.Features.Merchants.Commands.UpdateMerchant
{
    public class UpdateMerchantCommand : IRequest
    {
        public Guid Id { get; set; }
        public string BusinessName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public MerchantStatus Status { get; set; }
    }
}
