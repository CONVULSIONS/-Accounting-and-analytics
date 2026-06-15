using AccountingAndAnalytics.TaskManager.Models;
using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Interfaces
{
    public interface ITaskInDashboardVmFactory
    {
        TaskInDashboardViewModel Create(TaskModel task);
    }
}
