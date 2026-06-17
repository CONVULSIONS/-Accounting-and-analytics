using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using AccountingAndAnalytics.CRM.ViewModels.Pages;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.TaskManager.ViewModels.Pages;
using AccountingAndAnalytics.Shared.ViewModels.Pages;

namespace AccountingAndAnalytics.Shared.ViewModels.Elements
{
    public partial class SidebarViewModel : ViewModelBase
    {
        private readonly IHomeNavigationService _homeNavigationService;

        public string ApplicationsLabel { get; set; } = "Заявки";
        public string DealsLabel { get; set; } = "Сделки";
        public string DeadlinesLabel { get; set; } = "Сроки";
        public string UsersLabel { get; set; } = "Управление пользователями";

        private bool _isExpanded = true;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SidebarWidth));
                    OnPropertyChanged(nameof(SidebarArrow));
                }
            }
        }

        public double SidebarWidth => IsExpanded ? 220 : 52;
        public string SidebarArrow => IsExpanded ? "←" : "→";

        public ICommand ToggleSidebarCommand { get; }


        public SidebarViewModel(IHomeNavigationService homeNavigationService)
        {
            _homeNavigationService = homeNavigationService;


            ToggleSidebarCommand = new RelayCommand(() => IsExpanded = !IsExpanded);
        }


        [RelayCommand]
        private void GoToAppliaction()
        {
            _homeNavigationService.NavigateTo<ApplicationPageViewModel>();
        }
        [RelayCommand]
        private void GoToDeals()
        {
            _homeNavigationService.NavigateTo<DealPageViewModel>();
        }
        [RelayCommand]
        private void GoToDeadlineDashboard()
        {
            _homeNavigationService.NavigateTo<DeadlineDashboardPageViewModel>();
        }
        [RelayCommand]
        private void GoToUsers()
        {
            _homeNavigationService.NavigateTo<UserPageViewModel>();
        }
    }
}
