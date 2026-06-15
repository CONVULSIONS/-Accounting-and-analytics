using AccountingAndAnalytics.CRM.Interfaces.Api;
using AccountingAndAnalytics.CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Services.Api
{
    public class ApiRealEstateService : IRealEstateService
    {
        private readonly HttpClient _httpClient;
        public ApiRealEstateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RealEstateModel>> GetRealEstateAsync()
        {
            var response = await _httpClient
                .GetFromJsonAsync<List<RealEstateResponse>>("/real-estate/get-available-real-estate");

            if (response == null)
                return new List<RealEstateModel>();

            var realEsatateList = response
                .Select(x => new RealEstateModel
                    {
                        Id = x.id,
                        Name = x.name,
                    })
                .ToList();

            return realEsatateList;
        }
    }
}
