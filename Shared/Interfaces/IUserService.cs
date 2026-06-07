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
    }
}
