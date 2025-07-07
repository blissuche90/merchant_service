using GoTap.MerchantService.Application.Features.Merchants.Queries.Application.Merchants.Queries;
using GoTap.MerchantService.Domain.Entities;
using GoTap.MerchantService.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTap.MerchantService.Application.Features.Merchants.Queries.GetMerchantById
{
    public class GetMerchantByIdHandler : IRequestHandler<GetMerchantByIdQuery, Merchant?>
    {
        private readonly MerchantDbContext _context;

        public GetMerchantByIdHandler(MerchantDbContext context)
        {
            _context = context;
        }

        public async Task<Merchant?> Handle(GetMerchantByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Merchants.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
}
