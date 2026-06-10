using AccountingAndAnalytics.Shared.ViewModels;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.ViewModels.Elements
{
    public partial class CreateTaskViewModel : ViewModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; } = DateTime.Now;
        public DateTime Created { get; set; }
        public CreateTaskViewModel()
        {

        }

        [RelayCommand]
        private async Task CloseCreateDialog()
        {
            DialogHost.Close("MainDialog");
        }
    }

}
