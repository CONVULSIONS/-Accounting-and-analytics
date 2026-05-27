using AccountingAndAnalytics.Interfaces;
using AccountingAndAnalytics.Presentation.ViewModels;
using AccountingAndAnalytics.Presentation.ViewModels.Windows;
using AccountingAndAnalytics.Presentation.Views;
using AccountingAndAnalytics.Presentation.Views.Windows;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Lazy<MainViewModel> _mainViewModel;
        public void NavigateTo(ViewModelBase page)
        {
            _mainViewModel.Value.CurrentPage = page;
        }
        public void NavigateToMain(AuthorizationViewModel authorizationView) 
        {
            var mainWindow =
        _serviceProvider.GetRequiredService<MainWindow>();

            mainWindow.DataContext =
                _serviceProvider.GetRequiredService<MainViewModel>();

            mainWindow.Show();
        }
        public NavigationService(Lazy<MainViewModel> mainViewModel, IServiceProvider serviceProvider)
        {
            _mainViewModel = mainViewModel;
            _serviceProvider = serviceProvider;
        }
    }
}
