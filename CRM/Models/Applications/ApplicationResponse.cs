using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Models.Applications
{
    public class ApplicationResponse
    {
        public int id { get; set; }
        public int number { get; set; }
        public int real_estate_id { get; set; }
        public string real_estate_name { get; set; }
        public int client_id { get; set; }
        public string client_name { get; set; }
        public int status_id { get; set; }
        public string status_name { get; set; }
        public string title { get; set; }
        public DateOnly period { get; set; }
    }
}
