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
    public class CreateEditUserVmFactory : ICreateEditUserVmFactory
    {
        private readonly IServiceProvider _provider;
        public CreateEditUserVmFactory(IServiceProvider provider) => _provider = provider;

        public async Task<CreateEditUserViewModel> CreateAsync()
        {
            var vm = _provider.GetRequiredService<CreateEditUserViewModel>();
            await vm.InitCreate();
            return vm;
        }

        public async Task<CreateEditUserViewModel> EditAsync(UserModel user)
        {
            var vm = _provider.GetRequiredService<CreateEditUserViewModel>();
            await vm.InitEdit(user);
            return vm;
        }
    }
}
