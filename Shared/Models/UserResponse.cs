using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Models
{
    public class UserResponse
    {
        public int id { get; set; }
        public string login { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public string surname { get; set; }
        public int role_id { get; set; }
        public string role_name { get; set; }
        public int? department_id { get; set; }
        public string department_name { get; set; }
    }
}
