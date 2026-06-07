using AccountingAndAnalytics.Shared.Interfaces;
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
    public class ApiUserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly CurrentUserService _currentUser;

        public ApiUserService(HttpClient httpClient, CurrentUserService currentUser)
        {
            _httpClient = httpClient;
            _currentUser = currentUser;
        }

        public async Task<bool> GetUser(string login, string pass)
        {
            var response = await _httpClient
                .GetFromJsonAsync<LoginResponse>($"/auth/login/{login}/{pass}");

            if (response == null)
                return false;

            _currentUser.Set(response);
            return true;
        }
    }
}
