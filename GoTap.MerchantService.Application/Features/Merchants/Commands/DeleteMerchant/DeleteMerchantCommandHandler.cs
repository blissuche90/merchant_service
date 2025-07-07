using GoTap.MerchantService.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTap.MerchantService.Application.Features.Merchants.Commands.DeleteMerchant
{
    public class DeleteMerchantCommandHandler : IRequestHandler<DeleteMerchantCommand>
    {
        private readonly IMerchantRepository _repository;

        public DeleteMerchantCommandHandler(IMerchantRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
        {
            var merchant = await _repository.GetByIdAsync(request.Id);
            if (merchant == null)
                throw new KeyNotFoundException("Merchant not found.");

            await _repository.DeleteAsync(merchant);
            return Unit.Value;
        }
    }
}
