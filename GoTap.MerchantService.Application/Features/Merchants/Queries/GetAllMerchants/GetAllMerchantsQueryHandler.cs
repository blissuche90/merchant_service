using GoTap.MerchantService.Application.Interfaces;
using GoTap.MerchantService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTap.MerchantService.Application.Features.Merchants.Queries.GetAllMerchants
{
    public class GetAllMerchantsQueryHandler : IRequestHandler<GetAllMerchantsQuery, IEnumerable<Merchant>>
    {
        private readonly IMerchantRepository _repository;

        public GetAllMerchantsQueryHandler(IMerchantRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Merchant>> Handle(GetAllMerchantsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
