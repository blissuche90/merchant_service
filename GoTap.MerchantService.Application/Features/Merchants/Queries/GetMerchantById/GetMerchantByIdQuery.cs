using GoTap.MerchantService.Domain.Entities;
using MediatR;

namespace GoTap.MerchantService.Application.Features.Merchants.Queries
{
    namespace Application.Merchants.Queries
    {
        public record GetMerchantByIdQuery(Guid Id) : IRequest<Merchant?>;
    }
}
