using AccountingAndAnalytics.Analytics.ViewModels;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.Shared.Services;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingAndAnalytics.Shared.ViewModels.Pages
{
    public partial class ProfileViewModel : ViewModelBase
    {
        private readonly IAppNavigationService _appNavigationService;
        private readonly CurrentUserService _currentUser;

        public string Initials { get; private set; }
        public string FullName { get; private set; }
        public string Department { get; private set; }
        public string Role { get; private set; }
        public string LogoutLabel { get; private set; } = "Выйти";

        public StatisticViewModel Statistic { get; private set; }

        public ProfileViewModel(IAppNavigationService appNavigationService, CurrentUserService currentUser)
        {
            _appNavigationService = appNavigationService;
            _currentUser = currentUser;

            FullName = _currentUser.Surname + " " + _currentUser.FirstName + " " + _currentUser.SecondName;
            //Initials = _currentUser.FirstName[0].ToString() + _currentUser.SecondName[0].ToString();
            //Department = _currentUser.Department;
            Role = _currentUser.RoleName;

            Statistic = new StatisticViewModel();
        }

        [RelayCommand]
        private void Back()
        {
           _appNavigationService.NavigateTo<HomeViewModel>();
        }

        [RelayCommand]
        private void Logout()
        {
         //   _appNavigationService.NavigateTo<LoginViewModel>();
        }
    }
}
