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
using AccountingAndAnalytics.Shared.ViewModels;

namespace AccountingAndAnalytics.CRM.ViewModels.Elements
{
    public class ApplicationInListViewModel : ViewModelBase
    {
        public int Id { get; private set; }
        public int Number { get; private set; }
        public string RealEstateName { get; private set; }
        public string ClientName { get; private set; }
        public int Status { get; private set; }
        public string Title { get; private set; }

        public ApplicationInListViewModel(Application application)
        {
            Id = application.Id;
            Number = application.Number;
            ClientName = application.ClientName;
            RealEstateName = application.RealEstateName;
            Status = application.Status_id;
            Title = application.Title;
        }
    }
}
