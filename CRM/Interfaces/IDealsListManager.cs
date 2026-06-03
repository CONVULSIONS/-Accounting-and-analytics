using AccountingAndAnalytics.CRM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Interfaces
{
    public interface IDealsListManager
    {
        ObservableCollection<Deal> GetDeals();
    }
}
