using AccountingAndAnalytics.TaskManager.Interfaces.Factory;
using AccountingAndAnalytics.TaskManager.Models;
using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Services.Factory
{
    public class TaskInListVmFactory : ITaskInListVmFactory
    {
        private readonly IServiceProvider _provider;
        public TaskInListVmFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public TaskInListViewModel Create(TaskModel task, Func<Task> onRefresh)
        {
            var vm = _provider.GetRequiredService<TaskInListViewModel>();
            vm.Init(task, onRefresh);
            return vm;
        }
    }
}
