using GoTap.MerchantService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTap.MerchantService.Application.Features.Merchants.Commands.UpdateMerchant
{
    public class UpdateMerchantCommandHandler : IRequestHandler<UpdateMerchantCommand>
    {
        private readonly IMerchantRepository _repository;

        public UpdateMerchantCommandHandler(IMerchantRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateMerchantCommand request, CancellationToken cancellationToken)
        {
            var merchant = await _repository.GetByIdAsync(request.Id);
            if (merchant == null)
                throw new KeyNotFoundException("Merchant not found.");

            merchant.BusinessName = request.BusinessName;
            merchant.Email = request.Email;
            merchant.PhoneNumber = request.PhoneNumber;
            merchant.Country = request.Country;
            merchant.Status = request.Status;

            await _repository.UpdateAsync(merchant);
            return Unit.Value;
        }
    }
}
