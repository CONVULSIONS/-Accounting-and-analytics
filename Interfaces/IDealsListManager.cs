using AccountingAndAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Interfaces
{
    public interface IDealsListManager
    {
        ObservableCollection<Deal> GetDeals();
    }
}
