using AccountingAndAnalytics.Presentation.ViewModels;
using AccountingAndAnalytics.Presentation.ViewModels.Windows;
using AccountingAndAnalytics.Presentation.Views;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo(ViewModelBase page);
        void NavigateToMain(AuthorizationViewModel authorizationView);
    }
}
