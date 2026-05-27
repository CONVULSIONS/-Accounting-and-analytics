using AccountingAndAnalytics.Interfaces;
using AccountingAndAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Services
{
    public class FakeApplicationRepository : IApplicationRepozitory
    {
        private ObservableCollection<Application> _applications = new();
        public FakeApplicationRepository()
        {

            _applications.Add(new Application
            {
                Id = 1,
                Number = "я",
                RealEstateName = "заявка",
                ClientName = "привет"
            });
            _applications.Add(new Application
            {
                Id = 2,
                Number = "я",
                RealEstateName = "тоже",
                ClientName = "заявка"
            });
        }
        public ObservableCollection<Application> GetApplication()
        {
            return _applications;
        }
        public Application AddApplication(string number, string realEstate, string clientName)
        {
            var newApplication = new Application { Id = (_applications.Count + 1), Number = number, RealEstateName = realEstate, ClientName = clientName };
            _applications.Add(newApplication);
            return newApplication;
        }
        public void RemoveApplication(Application application)
        {
            _applications.Remove(application);
        }
    }
}
