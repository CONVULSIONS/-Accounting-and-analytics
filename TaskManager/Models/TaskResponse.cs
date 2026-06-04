using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Models
{
    public class TaskResponse
    {
        public int id { get; set; }
        public int number { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int deal_id { get; set; }
        public string deal_title { get; set; }
        public int user_id { get; set; }
        public int status_id { get; set; }
        public string status_name { get; set; }
        public DateOnly created { get; set; }
        public DateOnly deadline { get; set; }
        public DateOnly? ready { get; set; }

    }
}
