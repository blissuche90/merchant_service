using GoTap.MerchantService.Domain.Entities;
using MediatR;
using FluentValidation;
using GoTap.MerchantService.Persistence;
using GoTap.MerchantService.Application.Interfaces;

namespace GoTap.MerchantService.Application.Features.Merchants.Commands.CreateMerchant
{
    public class CreateMerchantHandler : IRequestHandler<CreateMerchantCommand, Guid>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly ICountryValidatorService _countryService;

        public CreateMerchantHandler(IMerchantRepository merchantRepository, ICountryValidatorService countryService)
        {
            _merchantRepository = merchantRepository;
            _countryService = countryService;
        }

        public async Task<Guid> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
        {
            if (!await _countryService.IsValidCountryAsync(request.Country))
                throw new ValidationException("Invalid country provided.");

            var merchant = new Merchant
            {
                Id = Guid.NewGuid(),
                BusinessName = request.BusinessName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Country = request.Country,
                Status = MerchantStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _merchantRepository.AddAsync(merchant);

            return merchant.Id;
        }
    }
}