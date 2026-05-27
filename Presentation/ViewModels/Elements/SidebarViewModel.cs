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
using AccountingAndAnalytics.Presentation.ViewModels.Pages;
using AccountingAndAnalytics.Services;

namespace AccountingAndAnalytics.Presentation.ViewModels.Elements
{
    public class SidebarViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;

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


        public SidebarViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoToApplicationCommand = new RelayCommand(GoToAppliaction);
            GoToDealsCommand = new RelayCommand(GoToDeals);


            ToggleSidebarCommand = new RelayCommand(() => IsSidebarExpanded = !IsSidebarExpanded);
        }



        private void GoToAppliaction()
        {
            _navigationService.NavigateTo(new ApplicationPageViewModel(new FakeApplicationRepository(), new FakeDealsRepozitory()));
        }
        private void GoToDeals()
        {
            _navigationService.NavigateTo(new DealsViewModel(new FakeDealsRepozitory()));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
