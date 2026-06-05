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
using System.Threading;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;

namespace AccountingAndAnalytics.CRM.ViewModels.Elements
{
    public partial class ApplicationInListViewModel : ViewModelBase
    {
        private readonly IApplicationRepozitory _repozitory;
        private int _id { get; set; }
        public int Number { get; private set; }
        public string Title { get; private set; }
        public string ClientTitle { get; private set; } = "Клиент:";
        public string ClientName { get; private set; }
        public string RealEstateTitle { get; private set; } = "Недвижимость:";
        public string RealEstateName { get; private set; }
        public string Status { get; private set; }
        public string PeriodTitle { get; private set; }
        public string Period { get; private set; }
        public string btnApproveTitle { get; private set; } = "Одобрить";
        public string btnRejectTitle { get; private set; } = "Отклонить";    

        public ApplicationInListViewModel(Application application, IApplicationRepozitory repozitory)
        {
            _repozitory = repozitory;
            _id = application.Id;
            Number = application.Number;
            ClientName = application.Client;
            RealEstateName = application.RealEstate;
            Status = application.Status;
            Title = application.Title;
            Period = application.Period.ToString();
        }

        [RelayCommand]
        private async Task Approve()
        {
            await _repozitory.AppToDeal(_id);
        }
    }
}
