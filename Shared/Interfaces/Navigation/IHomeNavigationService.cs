using AccountingAndAnalytics.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.Interfaces.Navigation
{
    public interface IHomeNavigationService
    {
        void NavigateTo<TViewModel>()
            where TViewModel : ViewModelBase;
    }
}
