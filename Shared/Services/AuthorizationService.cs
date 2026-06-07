using AccountingAndAnalytics.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private IUserService _userService;
        public AuthorizationService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> AuthorizeUser(string login, string pass)
        {
            return await _userService.GetUser(login, pass);
        }

    }
}
