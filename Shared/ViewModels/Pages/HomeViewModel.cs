using AccountingAndAnalytics.CRM.ViewModels.Pages;
using AccountingAndAnalytics.Interfaces;
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
    public class HomeViewModel : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;
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

        public HomeViewModel()
        {

        }
        public HomeViewModel(SidebarViewModel sidebar, IServiceProvider serviceProvider)
        {
            Sidebar = sidebar;
            _serviceProvider = serviceProvider;
            CurrentPage = new ApplicationPageViewModel(_serviceProvider.GetRequiredService<IApplicationRepozitory>(), _serviceProvider.GetRequiredService<IDealsRepozitory>());

        }
    }
}
