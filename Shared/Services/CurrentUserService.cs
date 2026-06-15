using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Services
{
    public class CurrentUserService
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string Surname { get; private set; }
        public int RoleId { get; private set; }
        public string RoleName { get; private set; }
        public int DepartmentId { get; private set; }
        public string DepartmentName { get; private set; }
        public string Token { get; private set; }

        public void Set(LoginResponse response)
        {
            Id = response.id;
            FirstName = response.first_name;
            SecondName = response.second_name;
            Surname = response.surname;
            RoleId = response.role_id;
            RoleName = response.role_name;
            //DepartmentId = response.department_id;
            //DepartmentName = response.department_name;
            Token = response.token;
            Debug.WriteLine($"SET USER {GetHashCode()}");
        }

        public void Clear()
        {
            Token = null;
        }
    }
}
