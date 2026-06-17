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
    public class ApiCommentService : ICommentService
    {
        private readonly HttpClient _httpClient;
        public ApiCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CommentModel>> GetByDealAsync(int dealId)
        {
            var response = await _httpClient
                .GetFromJsonAsync<List<CommentResponse>>($"/comments/get-by-deal/{dealId}");

            if (response == null)
                return new List<CommentModel>();

            return response
                .Select(x => new CommentModel
                {
                    Id = x.id,
                    UserName = x.user_name,
                    Text = x.text,
                    Time = x.time,
                })
                .ToList();
        }

        public async Task CreateAsync(int dealId, string text)
        {
            var data = new
            {
                deal_id = dealId,
                text = text
            };
            var response = await _httpClient.PostAsJsonAsync("/comments/create", data);
            response.EnsureSuccessStatusCode();
        }
    }
}
