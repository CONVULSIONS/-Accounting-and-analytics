using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.CRM.Models.Deals;
using AccountingAndAnalytics.CRM.ViewModels.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Services
{
    public class DealInListVmFactory : IDealInListVmFactory
    {
        public DealInListViewModel Create(Deal deal)
        {
            return new DealInListViewModel(deal);
        }
    }
}
