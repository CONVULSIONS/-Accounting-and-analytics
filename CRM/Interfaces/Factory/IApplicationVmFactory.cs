using AccountingAndAnalytics.CRM.Models.Applications;
using AccountingAndAnalytics.CRM.ViewModels.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Interfaces.Factory
{
    public interface IApplicationInListVmFactory
    {
        ApplicationInListViewModel Create(Application app);
    }
}
