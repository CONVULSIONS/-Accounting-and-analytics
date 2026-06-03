using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Models.Applications
{
    public class Application
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string RealEstateName { get; set; }
        public string ClientName { get; set; }
        public int Status_id { get; set; }
        public string Title { get; set; }
    }
}
