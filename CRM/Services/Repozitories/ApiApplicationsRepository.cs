using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AccountingAndAnalytics.CRM.Models.Applications;
using System.Net.Http.Json;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;

namespace AccountingAndAnalytics.CRM.Services.Repozitories
{
    public class ApiApplicationsRepository : IApplicationRepozitory
    {
        private readonly HttpClient _httpClient;
        public ApiApplicationsRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Application>> GetAllAsync()
        {
            var response = await _httpClient
                .GetFromJsonAsync<List<ApplicationResponse>>("/applications/get-all");

            if (response == null)
            {
                return new List<Application>();
            }

            var AppList = response
                            .Select(x => new Application
                            {
                                Id = x.id,
                                ClientId = x.client_id,
                                Client = x.client_name,
                                RealEstateId = x.real_estate_id,
                                RealEstate = x.real_estate_name,
                                StatusId = x.status_id,
                                Status = x.status_name,
                                Number = x.number,
                                Title = x.title,
                                Period = x.period,
                            })
                            .ToList();
            return AppList;
        }
        public async Task AppToDeal(int appId)
        {
            await _httpClient
                .PostAsync($"/applications/to-deal/{appId}", null);
        }
    }
}

