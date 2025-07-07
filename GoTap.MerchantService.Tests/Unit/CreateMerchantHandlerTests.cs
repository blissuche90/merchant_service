using FluentValidation;
using GoTap.MerchantService.Application.Features.Merchants.Commands.CreateMerchant;
using GoTap.MerchantService.Application.Interfaces;
using GoTap.MerchantService.Domain.Entities;
using FluentAssertions;
using Moq;

namespace GoTap.MerchantService.Tests.Unit
{
    public class CreateMerchantHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnGuid_WhenMerchantIsCreatedSuccessfully()
        {
            var merchantRepositoryMock = new Mock<IMerchantRepository>();
            var countryValidatorMock = new Mock<ICountryValidatorService>();

            countryValidatorMock
                .Setup(x => x.IsValidCountryAsync(It.IsAny<string>()))
                .ReturnsAsync(true);

            merchantRepositoryMock
                .Setup(x => x.AddAsync(It.IsAny<Merchant>()))
                .Returns(Task.CompletedTask);

            var handler = new CreateMerchantHandler(merchantRepositoryMock.Object, countryValidatorMock.Object);

            var command = new CreateMerchantCommand(
                "Test Business",
                "test@example.com",
                "1234567890",
                "Canada"
            );


            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBe(Guid.Empty);
            merchantRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Merchant>()), Times.Once);
            countryValidatorMock.Verify(x => x.IsValidCountryAsync("Canada"), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowValidationException_WhenCountryIsInvalid()
        {
            var merchantRepositoryMock = new Mock<IMerchantRepository>();
            var countryValidatorMock = new Mock<ICountryValidatorService>();

            countryValidatorMock
                .Setup(x => x.IsValidCountryAsync(It.IsAny<string>()))
                .ReturnsAsync(false);

            var handler = new CreateMerchantHandler(merchantRepositoryMock.Object, countryValidatorMock.Object);


            var command = new CreateMerchantCommand(
                "Invalid Country Business",
                "fail@example.com",
                "1234567890",
                "Invalidland"
            );


            var act = async () => await handler.Handle(command, CancellationToken.None);

            await act.Should()
                .ThrowAsync<ValidationException>()
                .WithMessage("Invalid country provided.");

            merchantRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Merchant>()), Times.Never);
        }
    }
}
