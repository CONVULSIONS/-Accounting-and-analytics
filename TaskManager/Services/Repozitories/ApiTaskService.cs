using AccountingAndAnalytics.TaskManager.Interfaces.Repozitories;
using AccountingAndAnalytics.TaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Services.Repozitories
{
    public class ApiTaskService : ITaskService
    {
        private readonly HttpClient _httpClient;
        public ApiTaskService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        public async Task<List<TaskModel>> GetAllByDealIdAsync(int dealId)
        {
            var response = await _httpClient
                .GetFromJsonAsync<List<TaskResponse>>($"/tasks/get-all-by-deal/{dealId}");
            
            if (response == null)
            {
                return new List<TaskModel>();
            }

            var taskList = response
                .Select(x => new TaskModel
                {
                    Id = x.id,
                    Number = x.number,
                    DealId = x.deal_id,
                    DealTitle = x.deal_title,
                    UserId = x.user_id,
                    StatusId = x.status_id,
                    StatusName = x.status_name,
                    Title = x.title,
                    Description = x.description,
                    Created = x.created,
                    Deadline = x.deadline,
                    Ready = x.ready,
                })
                .ToList();

            return taskList;
        }
    }
}
