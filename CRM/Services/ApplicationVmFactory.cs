using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.CRM.Models.Applications;
using AccountingAndAnalytics.CRM.ViewModels.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Services
{
    internal class ApplicationInListVmFactory : IApplicationInListVmFactory
    {
        public ApplicationInListViewModel Create(Application app)
        {
            return new ApplicationInListViewModel(app);
        }
    }
}
