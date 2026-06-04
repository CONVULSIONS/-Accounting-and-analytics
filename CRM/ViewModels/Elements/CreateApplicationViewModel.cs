using AccountingAndAnalytics.CRM.Models.Applications;
using AccountingAndAnalytics.Shared.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialogHostAvalonia;

namespace AccountingAndAnalytics.CRM.ViewModels.Elements
{
    public partial class CreateApplicationViewModel : ViewModelBase
    {
        public CreateApplicationViewModel() 
        {
            
        }
        [RelayCommand]
        public async Task CloseCreateDialog()
        {
            DialogHost.Close("MainDialog");
        }
    }
}
