using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Interfaces
{
     public interface ICreateEditTaskVmFactory
     {
        CreateEditTaskViewModel Create(int dealId);
        Task<CreateEditTaskViewModel> EditAsync(int taskId);
     }
}
