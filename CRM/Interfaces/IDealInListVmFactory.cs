using AccountingAndAnalytics.CRM.Models.Deals;
using AccountingAndAnalytics.CRM.ViewModels.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Interfaces
{
    public interface IDealInListVmFactory
    {
        DealInListViewModel Create(Deal deal);
    }
}
