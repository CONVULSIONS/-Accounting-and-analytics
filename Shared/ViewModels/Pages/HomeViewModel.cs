using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using AccountingAndAnalytics.CRM.ViewModels.Pages;
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
        public HeaderViewModel Header { get; }

        public HomeViewModel(SidebarViewModel sidebar, HeaderViewModel header, IServiceProvider serviceProvider)
        {
            Sidebar = sidebar;
            Header = header;
            _serviceProvider = serviceProvider;
            CurrentPage = new ApplicationPageViewModel(_serviceProvider.GetRequiredService<IApplicationRepozitory>(), _serviceProvider.GetRequiredService<IApplicationInListVmFactory>());

        }
    }
}
