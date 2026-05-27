using AccountingAndAnalytics.Interfaces;
using AccountingAndAnalytics.Presentation.ViewModels.Elements;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountingAndAnalytics.Presentation.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;
using AccountingAndAnalytics.Services;


namespace AccountingAndAnalytics.Presentation.ViewModels.Windows
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IServiceProvider _serviceProvider;
        private ViewModelBase _currentPage;
        public ViewModelBase CurrentPage
        { 
            get => _currentPage;
            set 
            { 
                _currentPage = value; 
                OnPropertyChanged(); 
            }
        }
        public SidebarViewModel Sidebar { get; }

        public MainViewModel(SidebarViewModel sidebar, IServiceProvider serviceProvider)
        {
            Sidebar = sidebar;
            _serviceProvider = serviceProvider;
            //CurrentPage = new DealsViewModel(_serviceProvider.GetRequiredService<IDealsRepozitory>());
            CurrentPage = new ApplicationPageViewModel(_serviceProvider.GetRequiredService<IApplicationRepozitory>(), _serviceProvider.GetRequiredService<IDealsRepozitory>());

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
