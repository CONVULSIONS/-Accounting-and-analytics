using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingAndAnalytics.Interfaces;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AccountingAndAnalytics.Services;
using AccountingAndAnalytics.CRM.ViewModels.Pages;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;

namespace AccountingAndAnalytics.Shared.ViewModels.Elements
{
    public class SidebarViewModel : ViewModelBase
    {
        private readonly IHomeNavigationService _homeNavigationService;

        private bool _isSidebarExpanded = true;
        public bool IsSidebarExpanded
        {
            get => _isSidebarExpanded;
            set
            {
                if (_isSidebarExpanded != value)
                {
                    _isSidebarExpanded = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SidebarWidth));
                    OnPropertyChanged(nameof(SidebarArrow));
                }
            }
        }

        public double SidebarWidth => IsSidebarExpanded ? 220 : 52;
        public string SidebarArrow => IsSidebarExpanded ? "←" : "→";

        public ICommand ToggleSidebarCommand { get; }
        public ICommand GoToApplicationCommand { get; }
        public ICommand GoToDealsCommand { get; }


        public SidebarViewModel(IHomeNavigationService homeNavigationService)
        {
            _homeNavigationService = homeNavigationService;

            GoToApplicationCommand = new RelayCommand(GoToAppliaction);
            GoToDealsCommand = new RelayCommand(GoToDeals);


            ToggleSidebarCommand = new RelayCommand(() => IsSidebarExpanded = !IsSidebarExpanded);
        }



        private void GoToAppliaction()
        {
            _homeNavigationService.NavigateTo<ApplicationPageViewModel>();
        }
        private void GoToDeals()
        {
            _homeNavigationService.NavigateTo<DealsViewModel>();
        }
    }
}
