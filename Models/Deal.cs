using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Models
{
    public class Deal
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string RealEstateName { get; set; }
        public string ClientName { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public ObservableCollection<DealTask> Tasks { get; set; } = new();
    }
}
