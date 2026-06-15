using AccountingAndAnalytics.TaskManager.Interfaces;
using AccountingAndAnalytics.TaskManager.Models;
using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Services
{
    public class TaskInDashboardVmFactory : ITaskInDashboardVmFactory
    {
        private readonly IServiceProvider _provider;
        public TaskInDashboardVmFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public TaskInDashboardViewModel Create(TaskModel task)
        {
            var vm = _provider.GetRequiredService<TaskInDashboardViewModel>();
            vm.Init(task);
            return vm;
        }
    }
}
