using AccountingAndAnalytics.Interfaces;
using AccountingAndAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Services
{
    public class CurrentUserSession : ICurrentUserSession
    {
        public User? CurrentUser { get; private set; } 
        public void SetCurrentUser(User currentUser)
        {
            CurrentUser = currentUser;
        }
    }
}
