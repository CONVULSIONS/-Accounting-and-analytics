using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AccountingAndAnalytics.CRM.Models.Applications;

namespace AccountingAndAnalytics.CRM.ViewModels.Elements
{
    public class ApplicationInListViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string RealEstate { get; set; }
        public string ClientName { get; set; }

        public ApplicationInListViewModel(Application application)
        {
            Id = application.Id;
            Number = application.Number;
            ClientName = application.ClientName;
            RealEstate = application.RealEstateName;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
