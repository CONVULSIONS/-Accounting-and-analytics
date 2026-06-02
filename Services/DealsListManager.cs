using AccountingAndAnalytics.CRM.Models;
using AccountingAndAnalytics.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Services
{
    public class DealsListManager : IDealsListManager
    {
        public ObservableCollection<Deal> GetDeals()
        {
            
            

            return new ObservableCollection<Deal>();
        }
    }
}
