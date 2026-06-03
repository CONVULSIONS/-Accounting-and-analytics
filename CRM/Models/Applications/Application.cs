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
        public int Number { get; set; }
        public int RealEstateId { get; set; }
        public string RealEstate { get; set; }
        public int ClientId { get; set; }
        public string Client { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
    }
}
