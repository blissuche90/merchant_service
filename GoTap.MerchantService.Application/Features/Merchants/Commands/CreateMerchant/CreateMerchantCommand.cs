using MediatR;

namespace GoTap.MerchantService.Application.Features.Merchants.Commands.CreateMerchant
{
    public record CreateMerchantCommand(string BusinessName, string Email, string PhoneNumber, string Country)
       : IRequest<Guid>;
}
