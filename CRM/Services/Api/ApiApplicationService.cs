using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using AccountingAndAnalytics.CRM.Models.Applications;
using AccountingAndAnalytics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Services.Repozitories
{
    public class ApiApplicationService : IApplicationService
    {
        private readonly HttpClient _httpClient;
        public ApiApplicationService(HttpClient httpClient)
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
        public async Task Create(string firstName, string secondName, string surname, int realEstateId, string realEstateName, DateOnly period)
        {
            var data = new
            {
                client_first_name = firstName,
                client_second_name = secondName,
                client_surname = surname,
                real_estate_id = realEstateId,
                real_estate_name = realEstateName,
                period = period.ToString("yyyy-MM-dd")
            };

            var response = await _httpClient.PostAsJsonAsync("/applications/create-application", data);
        }
        public async Task AppToDeal(int appId)
        {
            await _httpClient
                .PostAsync($"/applications/to-deal/{appId}", null);
        }
    }
}

