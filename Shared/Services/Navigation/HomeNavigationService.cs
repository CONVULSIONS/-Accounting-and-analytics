using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.Shared.ViewModels;
using AccountingAndAnalytics.Shared.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Services.Navigation
{
    public class HomeNavigationService : IHomeNavigationService
    {
        private readonly IServiceProvider _provider;
        private readonly Action<ViewModelBase> _setCurrentContent;
        public HomeNavigationService(
            IServiceProvider provider,
            Action<ViewModelBase> setCurrentContent)
        {
            _provider = provider;
            _setCurrentContent = setCurrentContent;
        }

        public void NavigateTo<TViewModel>()
            where TViewModel : ViewModelBase
        {
            var vm = _provider.GetRequiredService<TViewModel>();

            if (vm is IAsyncInitializable initVm)
            {
                _ = initVm.InitializeAsync();
            }

            _setCurrentContent(vm);                
        }
    }
}
