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

namespace AccountingAndAnalytics.CRM.ViewModels.Elements
{
    public class DealInListViewModel : ViewModelBase
    {
        private readonly IHomeNavigationService _navigation;
        private int _id { get; set; }
        public string Number { get; set; }
        public string RealEstate { get; set; }
        public string Client { get; set; }
        public string Deadline { get; set; }
        public string Status { get; set; }
        public string RealEstateTitle { get; } = "Недвижимость";
        public string ClientTitle { get; } = "Клиент";
        public string DeadlineTitle { get; } = "Срок до";
        public string TaskCountTitle { get; } = "Задач";

        public ICommand GoToTasksCommand { get; private set; }

        public DealInListViewModel(Deal deal, IHomeNavigationService navigation)
        {
            _navigation = navigation;
            _id = deal.Id;
            Number = deal.Number;
            RealEstate = deal.RealEstate;
            Client = deal.Client;
            Deadline = deal.Deadline.ToString();
            Status = deal.Status;
            Deadline = deal.Deadline.ToString();

            GoToTasksCommand = new RelayCommand(GoToTasks);
        }

        private void GoToTasks()
        {
            _navigation.NavigateTo<TaskPageViewModel, int>(_id);
        }
    }
}
