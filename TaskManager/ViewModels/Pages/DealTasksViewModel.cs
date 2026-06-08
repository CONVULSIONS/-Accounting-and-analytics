using AccountingAndAnalytics.CRM.ViewModels.Elements;
using AccountingAndAnalytics.CRM.Views.Elements;
using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.ViewModels;
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
    public partial class DealTasksViewModel : ViewModelBase, IAsyncInitializableParam<int>
    {
        private readonly ITaskService _taskService;
        private readonly ITaskInListVmFactory _factory;
        public string Title { get; } = "МОИ ЗАДАЧИ";
        public string NumberTitle { get; } = "Номер";
        public string TaskTitle { get; } = "Название";
        public string DeadlineTitle { get; } = "Срок";
        public string StatusTitle { get; } = "Статус";
        private int _dealId;
        public string Number { get; set; }
        public string Client { get; set; }
        public string RealEstate { get; set; }
        public string Period { get; set; }
        public string ClientExecutor { get; set; }
        public string LegalExecutor { get; set; }
        public string FinanceExecutor { get; set; }
        //public ObservableCollection<CommentViewModel> Comments { get; set; }
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

        public async Task InitializeAsync(int dealId)
        {
            _dealId = dealId;
            var taskList = await _taskService.GetAllByDealIdAsync(_dealId);

            foreach (var task in taskList)
            {
                _tasks.Add(_factory.Create(task));
            }
        }

        [RelayCommand]
        public async Task OpenCreateDialog()
        {
            var createVm = new CreateTaskViewModel();
            var createV = new CreateTaskView { DataContext = createVm };

            await DialogHost.Show(createV, "MainDialog");
            _tasks.Clear();
            await InitializeAsync(_dealId);
        }
    }
}
