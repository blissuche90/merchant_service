using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;


namespace GoTap.MerchantService.Tests.Integration
{
    public class MerchantApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public MerchantApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostMerchant_ShouldReturnCreated_WhenCountryIsValid()
        {
            var request = new
            {
                BusinessName = "IntegrationBiz",
                Email = "int@example.com",
                PhoneNumber = "1122334455",
                Status = "Active",
                Country = "Germany"
            };

            var response = await _client.PostAsJsonAsync("/api/merchants", request);

            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task PostMerchant_ShouldReturnBadRequest_WhenCountryIsInvalid()
        {
            var request = new
            {
                BusinessName = "FailBiz",
                Email = "fail@example.com",
                PhoneNumber = "9988776655",
                Status = "Pending",
                Country = "Atlantis"
            };

            var response = await _client.PostAsJsonAsync("/api/merchants", request);

            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
