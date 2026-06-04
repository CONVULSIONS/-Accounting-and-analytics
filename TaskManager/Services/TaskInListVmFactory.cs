using AccountingAndAnalytics.TaskManager.Interfaces;
using AccountingAndAnalytics.TaskManager.Models;
using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Services
{
    public class TaskInListVmFactory : ITaskInListVmFactory
    {
        public TaskInListViewModel Create(TaskModel task) => new TaskInListViewModel(task);
    }
}
