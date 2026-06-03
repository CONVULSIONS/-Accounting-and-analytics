using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using AccountingAndAnalytics.CRM.Models;
using AccountingAndAnalytics.CRM.Models.Applications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Services.Repozitories
{
    public class FakeDealsRepozitory : IDealsRepozitory
    {
        public ObservableCollection<Deal> _deals = new();
        public FakeDealsRepozitory()
        {
            var task1 = new DealTask { Id = 0, Title = "я задача" };
            var task2 = new DealTask { Id = 1, Title = "я тоже задача"};
            var taskList = new ObservableCollection<DealTask>();
            taskList.Add(task1);
            taskList.Add(task2);
            _deals.Add(new Deal
            {
                Id = 1,
                Number = "КП-00/11-0",
                RealEstateName = "офис",
                ClientName = "гендир",
                Deadline = new DateTime(2000, 6, 06),
                Status = "в ожидании",
                Tasks = taskList
            });
            _deals.Add(new Deal
            {
                Id = 2,
                Number = "КП-12/34-5",
                RealEstateName = "укит",
                ClientName = "мистер мгуту",
                Deadline = new DateTime(2666, 6, 06),
                Status = "аварийное",
                Tasks = taskList
            });
        }
        public ObservableCollection<Deal> GetDeals()
        {           
            return _deals;
        }
        public Deal AddDeal(string number, string realEstate, string clientName, DateTime dealline)
        {
            var newDeal = new Deal { Id = _deals.Count + 1, Number = number, RealEstateName = realEstate, ClientName = clientName, Deadline = dealline, Status = "привет" };
            _deals.Add(newDeal);
            return newDeal;
        }
        public Deal ApplicationToDeal(Application application)
        {
            //var newDealFromApplication = new Deal { Id = _deals.Count + 1, Number = application.Number, RealEstateName = application.RealEstateName, ClientName = application.ClientName, Deadline = new DateTime(1111, 1, 1), Status = "привет" };
            //_deals.Add(newDealFromApplication);
            return new Deal();
        }
    }
}
