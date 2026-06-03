using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Interfaces.Repozitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private IUserRepository _userRepository;
        private ICurrentUserSession _currentUserSession;
        public AuthorizationService(IUserRepository userRepository, ICurrentUserSession currentUserSession)
        {
            _userRepository = userRepository;
            _currentUserSession = currentUserSession;
        }

        public bool AuthorizeUser(string login, string pass)
        {
            var currentUser = _userRepository.GetUser(login, pass);
            if (currentUser == null) 
                return false;
            _currentUserSession.SetCurrentUser(currentUser);
            return true;
        }

    }
}
