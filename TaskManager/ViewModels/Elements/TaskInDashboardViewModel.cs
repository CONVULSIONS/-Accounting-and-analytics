using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.ViewModels.Elements
{
   public class TaskInDashboardViewModel
    {
        public string DealLabel { get; set; } = "Сделка";
        public string DealNumber { get; set; }
        public string TaskNumberLabel { get; set; } = "Номер задачи";
        public string TaskNumber { get; set; }
        public string Title { get; set; }
        public string DeadlineLabel { get; set; } = "Срок";
        public string Deadline { get; set; }

        public TaskInDashboardViewModel(string dealNumber, string taskNumber, string title, string deadline)
        {
            DealNumber = dealNumber;
            TaskNumber = taskNumber;
            Title = title;
            Deadline = deadline;
        }
    }
}
