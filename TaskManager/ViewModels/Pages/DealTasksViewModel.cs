using AccountingAndAnalytics.CRM.Models.Deals;
using AccountingAndAnalytics.CRM.ViewModels.Elements;
using AccountingAndAnalytics.CRM.Views.Elements;
using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.Shared.ViewModels;
using AccountingAndAnalytics.Shared.ViewModels.Pages;
using AccountingAndAnalytics.TaskManager.Interfaces;
using AccountingAndAnalytics.TaskManager.Interfaces.Repozitories;
using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using AccountingAndAnalytics.TaskManager.Views.Elements;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.ViewModels.Pages
{
    public partial class DealTasksViewModel : ViewModelBase, IAsyncInitializableParam<Deal>
    {
        private readonly ITaskService _taskService;
        private readonly ITaskInListVmFactory _factory;
        public string Title { get; set; } = "СДЕЛКА ";
        public string TaskTitle { get; } = "ЗАДАЧИ";
        public string ClientTitle { get; } = "КЛИЕНТ";
        public string RealEstateTitle { get; } = "ОБЪЕКТ НЕДВИЖИМОСТИ";
        public string PeriodTitle { get; } = "ДАТА ОКОНЧАНИЯ ПЕРИОДА";
        public string ExecutersTitle { get; set; } = "ИСПОЛНИТЕЛИ";
        public string ClientExecutorLabel { get; set; } = "Ответственный клиентского отдела";
        public string LegalExecutorLabel { get; set; } = "Ответственный юридического отдела";
        public string FinanceExecutorLabel { get; set; } = "Ответственный финансового отдела";
        public string btnCreateTitle { get; set; } = "+ Создать задачу";
        private Deal _deal {  get; set; }
        private string _number { get; set; }
        public string Number 
        { 
            get => _number; 
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged();
                }
            } 
        } 
        private string _client { get; set; }
        public string Client 
        { 
            get => _client; 
            set
            {
                if (_client != value)
                {
                    _client = value; 
                    OnPropertyChanged();
                }
            }
        }
        private string _realEstate { get; set; }
        public string RealEstate
        {
            get => _realEstate;
            set
            {
                if (_realEstate != value)
                {
                    _realEstate = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _period { get; set; }
        public string Period
        {
            get => _period;
            set
            {
                if (_period != value)
                {
                    _period = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _clientExecutor { get; set; }
        public string ClientExecutor
        {
            get => _clientExecutor;
            set
            {
                if (_clientExecutor != value)
                {
                    _clientExecutor = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _legalExecutor { get; set; }
        public string LegalExecutor
        {
            get => _legalExecutor;
            set
            {
                if (_legalExecutor != value)
                {
                    _legalExecutor = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _financeExecutor { get; set; }
        public string FinanceExecutor
        {
            get => _financeExecutor;
            set
            {
                if (_financeExecutor != value)
                {
                    _financeExecutor = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Comment1AuthorName { get; set; } = "Сергеев Олег Васильевич";
        public string Comment1CreatedAt { get; set; } = "14:32 03.09.26";
        public string Comment1Text { get; set; } = "Клиент подтвердил встречу на завтра.";

        public string Comment2AuthorName { get; set; } = "Петрова Мария Сергеевна";
        public string Comment2CreatedAt { get; set; } = "10:10 02.03.26";
        public string Comment2Text { get; set; } = "Договор отправлен на согласование в юридический отдел.";

        public string CommentWatermark { get; set; } = "Написать комментарий...";
        public string SendButtonLabel { get; set; } = "Отправить";
        public string CommentsTitle { get; set; } = "КОММЕНТАРИИ";



        public string NewComment { get; set; }
        private ObservableCollection<TaskInListViewModel> _tasks { get; set; } = new();
        public ObservableCollection<TaskInListViewModel> Tasks
        {
            get => _tasks;
            set
            {
                if (_tasks != value)
                {
                    _tasks = value;
                    OnPropertyChanged();
                }
            }
        }

        public DealTasksViewModel(ITaskService taskService, ITaskInListVmFactory factory)
        {
            _taskService = taskService;
            _factory = factory;
        }

        public async Task InitializeAsync(Deal deal)
        {
            _deal = deal;
            var taskList = await _taskService.GetAllByDealIdAsync(_deal.Id);

            foreach (var task in taskList)
            {
                _tasks.Add(_factory.Create(task));
            }
            Number = _deal.Number;
            Client = _deal.Client;
            RealEstate = _deal.RealEstate;
            Period = _deal.Period.ToString();
            FinanceExecutor = "Петрова Мария Сергеевна";
            LegalExecutor = "Сидоров Василий Павлович";
            ClientExecutor = "Сергеев Олег Васильевич";
        }

        [RelayCommand]
        public async Task OpenCreateDialog()
        {
            var createVm = new CreateTaskViewModel();
            var createV = new CreateTaskView { DataContext = createVm };

            await DialogHost.Show(createV, "MainDialog");
            _tasks.Clear();
            await InitializeAsync(_deal);
        }
    }
}
