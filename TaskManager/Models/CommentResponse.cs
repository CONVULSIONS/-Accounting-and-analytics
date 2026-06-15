using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.Models
{
    public class CommentResponse
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string text { get; set; }
        public DateTime time { get; set; }
    }
}
