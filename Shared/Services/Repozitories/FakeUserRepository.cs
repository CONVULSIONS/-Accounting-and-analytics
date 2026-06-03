using AccountingAndAnalytics.Shared.Interfaces.Repozitories;
using AccountingAndAnalytics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Services.Repozitories
{
    internal class FakeUserRepository : IUserRepository
    {
        public User? GetUser(string login, string pass)
        {
            return new User(1, "name", "sername", "bebe");

        }
    }
}
