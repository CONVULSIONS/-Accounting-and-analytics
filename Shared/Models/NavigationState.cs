using AccountingAndAnalytics.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingAndAnalytics.Shared.ViewModels.Pages;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingAndAnalytics.Shared.Models
{
    public class NavigationState : ViewModelBase
    {
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
    }
}
