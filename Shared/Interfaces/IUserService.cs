using AccountingAndAnalytics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Interfaces
{
    public interface IUserService
    {
        Task<bool> GetUser(string login, string pass);
        Task<List<UserModel>> GetAllAsync();
        Task CreateAsync(string firstName, string secondName, string surname, string login, string password, int roleId, int? departmentId);
        Task EditAsync(int userId, string firstName, string secondName, string surname, string login, string password, int roleId, int? departmentId);
        Task DeleteAsync(int userId);
        Task<List<RoleModel>> GetRolesAsync();
        Task<List<DepartmentModel>> GetDepartmentsAsync();
    }
}
