using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Models;
using AccountingAndAnalytics.Shared.ViewModels.Elements;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Services
{
    public class UserInListVmFactory : IUserInListVmFactory
    {
        private readonly IServiceProvider _provider;
        public UserInListVmFactory(IServiceProvider provider) => _provider = provider;

        public UserInListViewModel Create(UserModel user, Func<Task> onRefresh)
        {
            var vm = _provider.GetRequiredService<UserInListViewModel>();
            vm.Init(user, onRefresh);
            return vm;
        }
    }
}
