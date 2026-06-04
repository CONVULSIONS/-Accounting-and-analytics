using AccountingAndAnalytics.TaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Interfaces.Repozitories
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAllByDealIdAsync(int dealId);
    }
}
