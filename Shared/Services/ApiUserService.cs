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
                .GetFromJsonAsync<LoginResponse>($"/users/login/{login}/{pass}");

            if (response == null)
                return false;

            _currentUser.Set(response);
            return true;
        }
        public async Task<List<UserModel>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<UserResponse>>("/users/get-all");
            if (response == null) return new List<UserModel>();
            return response.Select(x => new UserModel
            {
                Id = x.id,
                Login = x.login,
                FirstName = x.first_name,
                SecondName = x.second_name,
                Surname = x.surname,
                RoleId = x.role_id,
                RoleName = x.role_name,
                DepartmentId = x.department_id,
                DepartmentName = x.department_name,
            }).ToList();
        }

        public async Task CreateAsync(string firstName, string secondName, string surname, string login, string password, int roleId, int? departmentId)
        {
            var data = new
            {
                first_name = firstName,
                second_name = secondName,
                surname = surname,
                login = login,
                password = password,
                role_id = roleId,
                department_id = departmentId
            };
            var response = await _httpClient.PostAsJsonAsync("/users/create", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task EditAsync(int userId, string firstName, string secondName, string surname, string login, string password, int roleId, int? departmentId)
        {
            var data = new
            {
                first_name = firstName,
                second_name = secondName,
                surname = surname,
                login = login,
                password = password,
                role_id = roleId,
                department_id = departmentId
            };
            var response = await _httpClient.PatchAsJsonAsync($"/users/edit/{userId}", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int userId)
        {
            var response = await _httpClient.DeleteAsync($"/users/delete/{userId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<RoleModel>> GetRolesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ReferenceResponse>>("/references/roles");
            if (response == null) return new List<RoleModel>();
            return response.Select(x => new RoleModel { Id = x.id, Name = x.name }).ToList();
        }

        public async Task<List<DepartmentModel>> GetDepartmentsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ReferenceResponse>>("/references/departments");
            if (response == null) return new List<DepartmentModel>();
            return response.Select(x => new DepartmentModel { Id = x.id, Name = x.name }).ToList();
        }
    }
}
