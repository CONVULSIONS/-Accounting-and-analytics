using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.Shared.Models;
using AccountingAndAnalytics.Shared.Services;
using AccountingAndAnalytics.Shared.Services.Navigation;
using AccountingAndAnalytics.Shared.ViewModels.Pages;
using System.Threading.Tasks;


namespace AccountingAndAnalytics.Shared.ViewModels.Windows
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationState _navigationState;
        private readonly IAppNavigationService _appNavigationService;

        public ViewModelBase? CurrentPage
        { 
            get => _navigationState.CurrentPage;
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
            _appNavigationService.NavigateTo<HomeViewModel>();
        }
    }
}
