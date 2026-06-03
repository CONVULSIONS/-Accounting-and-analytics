using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Models
{
    public class LoginResponse
    {
        public string token { get; set; }
        public string role { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
