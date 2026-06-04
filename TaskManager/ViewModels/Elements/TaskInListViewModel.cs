using AccountingAndAnalytics.TaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.ViewModels.Elements
{
    public class TaskInListViewModel
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Deadline { get; set; }
        public string Status { get; set; }
        public TaskInListViewModel(TaskModel task)
        {
            Number = task.Number;
            Title = task.Title;
            Deadline = task.Deadline.ToString();
            Status = task.StatusName;
        }
    }
}
