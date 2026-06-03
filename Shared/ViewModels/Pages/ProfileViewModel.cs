using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace AccountingAndAnalytics.Shared.ViewModels.Pages
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly IAppNavigationService _navigation;

        public ProfileViewModel(IAppNavigationService navigation)
        {
            _navigation = navigation;
            BackCommand = new RelayCommand(Back);
        }

        public ICommand BackCommand { get; }
        private void Back()
        {
            _navigation.NavigateTo<HomeViewModel>();
        }
    }
}
