using AccountingAndAnalytics.Shared.Interfaces.Repozitories;
using AccountingAndAnalytics.Shared.Models;
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
        public ApiApplicationsRepository()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://127.0.0.1:8000")
            };
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
                                ClientName = x.client_name,
                                RealEstateId = x.real_estate_id,
                                RealEstateName = x.real_estate_name,
                                Status_id = x.status_id,
                                Number = x.number,
                                Title = x.title
                            })
                            .ToList();
            return AppList;
        }
    }
}
//public class ApiUserRepository : IUserRepository
//{
//    private readonly HttpClient _httpClient;

//    public ApiUserRepository()
//    {
//        _httpClient = new HttpClient
//        {
//            BaseAddress = new Uri("http://127.0.0.1:8000")
//        };
//    }

//    public User? GetUser(string login, string pass)
//    {
//        var request = new { login, password = pass };
//        var response = _httpClient
//            .PostAsJsonAsync("/auth/login", request)
//            .Result;

//        if (!response.IsSuccessStatusCode)
//            return null;

//        var result = response.Content
//            .ReadFromJsonAsync<LoginResponse>()
//            .Result;

//        return result == null ? null : new User(0, result.first_name, result.last_name, result.role);
//    }
//}
