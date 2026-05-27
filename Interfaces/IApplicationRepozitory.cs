using AccountingAndAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Interfaces
{
    public interface IApplicationRepozitory
    {
        ObservableCollection<Application> GetApplication();
        Application AddApplication(string number, string realEstate, string clientName);
        void RemoveApplication(Application application);
    }
}
