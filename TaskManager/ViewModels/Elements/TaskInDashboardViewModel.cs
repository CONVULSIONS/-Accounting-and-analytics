using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.ViewModels.Elements
{
   public class TaskInDashboardViewModel
    {
        public string DealNumber { get; set; }
        public string TaskNumber { get; set; }
        public string Title { get; set; }
        public string Deadline { get; set; }
    }
}
