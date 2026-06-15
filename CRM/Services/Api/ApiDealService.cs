using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using AccountingAndAnalytics.CRM.Models.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Services.Repozitories
{
    public class ApiDealService : IDealRepozitory
    {
        private readonly HttpClient _httpClient;
        public ApiDealService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
        }
        public async Task<List<Deal>> GetAllAsync()
        {
            var response = await _httpClient
                .GetFromJsonAsync<List<DealResponse>>("/deals/get-all");

            if (response == null)
            {
                return new List<Deal>();
            }

            var dealList = response
                            .Select(x => new Deal
                            {
                                Id = x.id,
                                Number = x.number,
                                ClientId = x.client_id,
                                Client = x.client_name,
                                RealEstateId = x.real_estate_id,
                                RealEstate = x.real_estate_name,
                                StatusId = x.status_id,
                                Status = x.status_name,
                                Period = x.period
                            })
                            .ToList();
            return dealList;
        } 
    }
}
