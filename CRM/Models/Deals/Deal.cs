using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Models.Deals
{
    public class Deal
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int RealEstateId { get; set; }
        public string RealEstate { get; set; }
        public int ClientId { get; set; }
        public string Client { get; set; }
        public DateOnly Deadline { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }

    }
}
