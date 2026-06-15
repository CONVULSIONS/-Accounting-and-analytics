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
        public async Task<List<TaskModel>> GetAllByUserAsync()
        {
            var response = await _httpClient
                .GetFromJsonAsync<List<TaskResponse>>("/tasks/get-by-user");
            if (response == null)
                return new List<TaskModel>();
            return response.Select(x => new TaskModel
            {
                Id = x.id,
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
            }).ToList();
        }
        public async Task<TaskModel> GetTaskByIdAsync(int taskId)
        {
            var response = await _httpClient
                .GetFromJsonAsync<TaskResponse>($"/tasks/get-by-id/{taskId}");

            if (response == null)
                return new TaskModel();

            var task = new TaskModel
                {
                    Id = response.id,
                    DealId = response.deal_id,
                    DealTitle = response.deal_title,
                    UserId = response.user_id,
                    StatusId = response.status_id,
                    StatusName = response.status_name,
                    Title = response.title,
                    Description = response.description,
                    Created = response.created,
                    Deadline = response.deadline,
                    Ready = response.ready,
                };
            return task;
        } 
        public async Task CreateAsync(string title, string description, DateOnly deadline, DateOnly created, int dealId)
        {
            var newTask = new
            {
                title = title,
                description = description,
                deadline = deadline,
                created = created,
                deal_id = dealId,
            };

            var response = await _httpClient.PostAsJsonAsync("/tasks/create", newTask);
        }
        public async Task EditAsync(int taskId, string title, string description, DateOnly deadline)
        {
            var data = new
            {
                title = title,
                description = description,
                deadline = deadline
            };

            var response = await _httpClient
                .PatchAsJsonAsync($"/tasks/edit/{taskId}", data);
        }
        public async Task DeleteAsync(int taskId)
        {
            await _httpClient.DeleteAsync($"/tasks/delete/{taskId}");
        }
    }
}
