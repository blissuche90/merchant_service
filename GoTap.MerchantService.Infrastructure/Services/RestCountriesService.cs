using GoTap.MerchantService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTap.MerchantService.Infrastructure.Services
{
    public class RestCountriesService : ICountryValidatorService
    {
        private readonly HttpClient _httpClient;

        public RestCountriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> IsValidCountryAsync(string country)
        {
            var response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{country}");
            return response.IsSuccessStatusCode;
        }
    }
}
