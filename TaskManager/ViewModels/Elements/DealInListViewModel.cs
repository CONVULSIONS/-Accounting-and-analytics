using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AccountingAndAnalytics.CRM.Models;
using AccountingAndAnalytics.CRM.Models.Deals;
using AccountingAndAnalytics.Shared.ViewModels;
using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.TaskManager.ViewModels.Pages;
using System.Threading;

namespace AccountingAndAnalytics.TaskManager.ViewModels.Elements
{
    public class DealInListViewModel : ViewModelBase
    {
        private readonly IHomeNavigationService _navigation;
        private int _id { get; set; }
        public string Number { get; set; }
        public string RealEstate { get; set; }
        public string Client { get; set; }
        public string Period { get; set; }
        public string Status { get; set; }

        public ICommand GoToTasksCommand { get; private set; }

        public DealInListViewModel(Deal deal, IHomeNavigationService navigation)
        {
            _navigation = navigation;
            _id = deal.Id;
            Number = deal.Number;
            RealEstate = deal.RealEstate;
            Client = deal.Client;
            Period= deal.Period.ToString();
            Status = deal.Status;

            GoToTasksCommand = new RelayCommand(GoToTasks);
        }

        private void GoToTasks()
        {
            _navigation.NavigateTo<DealTasksViewModel, int>(_id);
        }
    }
}
