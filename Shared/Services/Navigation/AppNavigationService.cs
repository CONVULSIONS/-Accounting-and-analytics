using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.Shared.Models;
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
    public class AppNavigationService : IAppNavigationService
    {
        private readonly IServiceProvider _provider;
        private readonly NavigationState _state;
        public AppNavigationService( IServiceProvider provider, NavigationState state)
        {
            _provider = provider;
            _state = state;
        }

        public void NavigateTo<TViewModel>()
            where TViewModel : ViewModelBase
        {
            var vm = _provider.GetRequiredService<TViewModel>();

            if (vm is IAsyncInitializable initVm)
            {
                _ = initVm.InitializeAsync();
            }

            _state.CurrentPage = vm;                
        }
    }
}
