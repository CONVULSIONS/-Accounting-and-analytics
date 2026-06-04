using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int DealId { get; set; }
        public string DealTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly Created { get; set; }
        public DateOnly Deadline { get; set; }
        public DateOnly? Ready { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
