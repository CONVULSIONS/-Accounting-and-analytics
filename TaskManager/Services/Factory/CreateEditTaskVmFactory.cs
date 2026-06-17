using AccountingAndAnalytics.TaskManager.Interfaces.Factory;
using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Services.Factory
{
    public class CreateEditTaskVmFactory : ICreateEditTaskVmFactory
    {
        private readonly IServiceProvider _provider;
        public CreateEditTaskVmFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public CreateEditTaskViewModel Create(int dealId)
        {
            var vm = _provider.GetRequiredService<CreateEditTaskViewModel>();
            vm.InitCreate(dealId);
            return vm;
        }
        public async Task<CreateEditTaskViewModel> EditAsync(int taskId)
        {
            var vm = _provider.GetRequiredService<CreateEditTaskViewModel>();
            await vm.InitEdit(taskId);
            return vm;
        }
    }
}
