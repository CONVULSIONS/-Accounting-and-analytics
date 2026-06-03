using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountingAndAnalytics.Shared.ViewModels.Pages;
using CommunityToolkit.Mvvm.Input;

namespace AccountingAndAnalytics.Shared.ViewModels.Elements
{
    public class HeaderViewModel : ViewModelBase
    {
        private readonly IAppNavigationService _appNavigationService;

        public HeaderViewModel(IAppNavigationService appNavigationService)
        {
            _appNavigationService = appNavigationService;
            OpenProfileCommand = new RelayCommand(OpenProfile);
        }

        public ICommand OpenProfileCommand { get; }
        private void OpenProfile()
        {
            _appNavigationService.NavigateTo<ProfileViewModel>();
        }
    }
}
