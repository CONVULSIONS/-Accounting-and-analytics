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
        Task<List<TaskModel>> GetAllByUserAsync();
        Task<TaskModel> GetTaskByIdAsync(int taskId);
        Task CreateAsync(string title, string description, DateOnly deadline, DateOnly created, int dealId);
        Task EditAsync(int taskId, string title, string description, DateOnly deadline);
        Task DeleteAsync(int taskId);
    }
}
