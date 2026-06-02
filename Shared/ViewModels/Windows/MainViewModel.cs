using AccountingAndAnalytics.Interfaces;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountingAndAnalytics.CRM.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;
using AccountingAndAnalytics.Services;
using AccountingAndAnalytics.Shared.ViewModels;
using AccountingAndAnalytics.Shared.ViewModels.Elements;
using AccountingAndAnalytics.Shared.ViewModels.Pages;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.Shared.Models;


namespace AccountingAndAnalytics.Shared.ViewModels.Windows
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationState _navigationState;
        private readonly IAppNavigationService _appNavigationService;
        //private ViewModelBase? _currentPage;
        public ViewModelBase? CurrentPage
        { 
            get => _navigationState.CurrentPage;
            set 
            { 
                //_currentPage = value; 
                //OnPropertyChanged(); 
            }
        }
        public MainViewModel()
        {

        }
        public MainViewModel(NavigationState state, IAppNavigationService appNavigationService)
        {
            _navigationState = state;
            _navigationState.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(NavigationState.CurrentPage))
                    OnPropertyChanged(nameof(CurrentPage));
            };
            _appNavigationService = appNavigationService;
            _appNavigationService.NavigateTo<AuthorizationViewModel>();
        }
    }
}
