using AccountingAndAnalytics.Shared.Interfaces.Repozitories;
using AccountingAndAnalytics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Services
{
    public class ApiUserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;

        public ApiUserRepository()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://127.0.0.1:8000")
            };
        }

        public User? GetUser(string login, string pass)
        {
            var request = new { login, password = pass };
            var response = _httpClient
                .PostAsJsonAsync("/auth/login", request)
                .Result;

            if (!response.IsSuccessStatusCode)
                return null;

            var result = response.Content
                .ReadFromJsonAsync<LoginResponse>()
                .Result;

            return result == null ? null : new User(0, result.first_name, result.last_name, result.role);
        }
    }
}
