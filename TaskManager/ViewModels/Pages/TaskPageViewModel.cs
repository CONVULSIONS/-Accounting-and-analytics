using AccountingAndAnalytics.Shared.ViewModels;
using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.TaskManager.Interfaces;
using AccountingAndAnalytics.TaskManager.Interfaces.Repozitories;
using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.ViewModels.Pages
{
    public class TaskPageViewModel : ViewModelBase, IAsyncInitializableParam<int>
    {
        private readonly ITaskService _taskService;
        private readonly ITaskInListVmFactory _factory;
        public string Title { get; } = "МОИ ЗАДАЧИ";
        public string NumberTitle { get; } = "Номер";
        public string TaskTitle { get; } = "Название";
        public string DeadlineTitle { get; } = "Срок";
        public string StatusTitle { get; } = "Статус";
        private int _dealId;
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

        public TaskPageViewModel(ITaskService taskService, ITaskInListVmFactory factory)
        {
            _taskService = taskService;
            _factory = factory;
        }

        public async Task InitializeAsync(int dealId)
        {
            _dealId = dealId;
            var taskList = await _taskService.GetAllByDealIdAsync(_dealId);

            foreach (var deal in taskList)
            {
                _tasks.Add(_factory.Create(deal));
            }
        }
    }
}
