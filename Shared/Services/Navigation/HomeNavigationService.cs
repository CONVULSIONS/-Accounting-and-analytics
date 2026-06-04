using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.Shared.ViewModels;
using AccountingAndAnalytics.Shared.ViewModels.Pages;
using AccountingAndAnalytics.Shared.ViewModels.Windows;
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
        public void NavigateTo<TViewModel, TParameter>(TParameter parameter)
            where TViewModel : ViewModelBase
        {
            var vm = _provider.GetRequiredService<TViewModel>();

            if (vm is IAsyncInitializableParam<TParameter> init)
            {
                _ = init.InitializeAsync(parameter);
            }

            _setCurrentContent(vm);
        }
    }
}
