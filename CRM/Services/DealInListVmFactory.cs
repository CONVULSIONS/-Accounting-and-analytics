using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.CRM.Models.Deals;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.CRM.Services
{
    public class DealInListVmFactory : IDealInListVmFactory
    {
        private readonly IServiceProvider _provider;
        public DealInListVmFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public DealInListViewModel Create(Deal deal) => new DealInListViewModel(deal, _provider.GetRequiredService<IHomeNavigationService>());
    }
}
