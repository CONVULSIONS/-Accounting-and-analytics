using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Services
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly CurrentUserService _currentUser;

        public AuthHeaderHandler(CurrentUserService currentUser)
        {
            _currentUser = currentUser;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken ct)
        {
            if (_currentUser.Token != null)
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", _currentUser.Token);
            return base.SendAsync(request, ct);
        }
    }
}
