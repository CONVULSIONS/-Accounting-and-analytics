using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.Shared.Services;
using AccountingAndAnalytics.Shared.ViewModels.Pages;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingAndAnalytics.Shared.ViewModels.Elements
{
    public partial class HeaderViewModel : ViewModelBase
    {
        private readonly IAppNavigationService _appNavigationService;
        private readonly CurrentUserService? _currentUser;
        public string Title { get; set; } = "Учет и аналитика";
        public string Initials { get; private set; }
        public string RoleName { get; private set; }
        public string FullName { get; private set; }
        public HeaderViewModel(IAppNavigationService appNavigationService, CurrentUserService currentUser)
        {
            _appNavigationService = appNavigationService;
            _currentUser = currentUser;
            //Initials = _currentUser.FirstName[0].ToString() + _currentUser.SecondName[0].ToString();
            Initials = "ВД";
            RoleName = _currentUser.RoleName;
            FullName = _currentUser.Surname + " " + _currentUser.FirstName + " " + _currentUser.SecondName;
        }


        [RelayCommand]
        private void OpenProfile()
        {
            _appNavigationService.NavigateTo<ProfileViewModel>();
        }
    }
}
