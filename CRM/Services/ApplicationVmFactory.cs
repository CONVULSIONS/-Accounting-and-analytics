using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using AccountingAndAnalytics.CRM.Models.Applications;
using AccountingAndAnalytics.CRM.ViewModels.Elements;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Services
{
    internal class ApplicationInListVmFactory : IApplicationInListVmFactory
    {
        private readonly IServiceProvider _provider;
        public ApplicationInListVmFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public ApplicationInListViewModel Create(Application app)
        {
            return new ApplicationInListViewModel(app, _provider.GetRequiredService<IApplicationRepozitory>());
        }
    }
}
