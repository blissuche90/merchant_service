﻿using GoTap.MerchantService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTap.MerchantService.Application.Features.Merchants.Queries.GetAllMerchants
{
    public record GetAllMerchantsQuery : IRequest<IEnumerable<Merchant>>;
}
