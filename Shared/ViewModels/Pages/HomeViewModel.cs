using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using AccountingAndAnalytics.CRM.ViewModels.Pages;
using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Services;
using AccountingAndAnalytics.Shared.ViewModels.Elements;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.ViewModels.Pages
{
    public class HomeViewModel : ViewModelBase, IAsyncInitializable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthorizationService _authorizationService;
        private ViewModelBase? _currentPage;
        public ViewModelBase? CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public SidebarViewModel Sidebar { get; }
        private HeaderViewModel _header;
        public HeaderViewModel Header 
        {
            get => _header;
            set
            {
                _header = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel(SidebarViewModel sidebar, HeaderViewModel header, IServiceProvider serviceProvider, IAuthorizationService authorizationService)
        {
            Sidebar = sidebar;
            //Header = header;
            _serviceProvider = serviceProvider;
            _authorizationService = authorizationService;
            CurrentPage = _serviceProvider.GetRequiredService<ApplicationPageViewModel>();

        }
        public async Task InitializeAsync()
        {            
            await _authorizationService.AuthorizeUser("lera_alex", "2007");
            Header = _serviceProvider.GetRequiredService<HeaderViewModel>();
        }
    }
}
