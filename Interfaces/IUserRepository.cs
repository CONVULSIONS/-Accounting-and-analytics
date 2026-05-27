using AccountingAndAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Interfaces
{
    public interface IUserRepository
    {
        User? GetUser(string login, string pass);
    }
}
