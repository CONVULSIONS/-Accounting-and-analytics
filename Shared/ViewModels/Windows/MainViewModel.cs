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
            _appNavigationService.NavigateTo<HomeViewModel>();
        }
    }
}
