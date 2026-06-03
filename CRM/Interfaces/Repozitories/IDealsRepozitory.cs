using AccountingAndAnalytics.CRM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Interfaces.Repozitories
{
    public interface IDealsRepozitory
    {
        ObservableCollection<Deal> GetDeals();
        Deal AddDeal(string number, string realEstate, string ClientName, DateTime dealline);
        Deal ApplicationToDeal(Application application);
    }
}
