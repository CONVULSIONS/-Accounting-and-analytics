using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Interfaces
{
    public interface IAuthorizationService
    {
        bool AuthorizeUser(string login, string pass);
    }
}
