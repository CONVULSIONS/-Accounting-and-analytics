using AccountingAndAnalytics.Shared.ViewModels;
using AccountingAndAnalytics.TaskManager.Interfaces.Factory;
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
    public partial class DeadlineDashboardPageViewModel : ViewModelBase
    {
        private readonly ITaskService _taskService;
        private readonly ITaskInDashboardVmFactory _factory;

        public string PageTitle { get; set; } = "Сроки";
        public string OverdueLabel { get; set; } = "Просрочено";
        public string CompletedLabel { get; set; } = "Выполнено";
        public string WeekLabel { get; set; } = "На этой неделе";
        public string NextWeekLabel { get; set; } = "Через неделю";
        public string NextMonthLabel { get; set; } = "Через месяц";
        public string LaterLabel { get; set; } = "Более месяца";

        private ObservableCollection<TaskInDashboardViewModel> _overdue = new();
        public ObservableCollection<TaskInDashboardViewModel> Overdue
        {
            get => _overdue;
            set { _overdue = value; OnPropertyChanged(); }
        }
        private ObservableCollection<TaskInDashboardViewModel> _completed = new();
        public ObservableCollection<TaskInDashboardViewModel> Completed
        {
            get => _completed;
            set { _completed = value; OnPropertyChanged(); }
        }
        private ObservableCollection<TaskInDashboardViewModel> _week = new();
        public ObservableCollection<TaskInDashboardViewModel> Week
        {
            get => _week;
            set { _week = value; OnPropertyChanged(); }
        }
        private ObservableCollection<TaskInDashboardViewModel> _nextWeek = new();
        public ObservableCollection<TaskInDashboardViewModel> NextWeek
        {
            get => _nextWeek;
            set { _nextWeek = value; OnPropertyChanged(); }
        }
        private ObservableCollection<TaskInDashboardViewModel> _nextMonth = new();
        public ObservableCollection<TaskInDashboardViewModel> NextMonth
        {
            get => _nextMonth;
            set { _nextMonth = value; OnPropertyChanged(); }
        }
        private ObservableCollection<TaskInDashboardViewModel> _later = new();
        public ObservableCollection<TaskInDashboardViewModel> Later
        {
            get => _later;
            set { _later = value; OnPropertyChanged(); }
        }

        public DeadlineDashboardPageViewModel(ITaskService taskService, ITaskInDashboardVmFactory factory)
        {
            _taskService = taskService;
            _factory = factory;
            _ = LoadAsync();
        }

        private async Task LoadAsync()
        {
            try
            {
                var tasks = await _taskService.GetAllByUserAsync();
                var today = DateOnly.FromDateTime(DateTime.Now);
                var weekEnd = today.AddDays(7);
                var nextWeekEnd = today.AddDays(14);
                var monthEnd = today.AddDays(30);

                foreach (var task in tasks)
                {
                    var vm = _factory.Create(task);

                    if (task.Ready != null)
                        Completed.Add(vm);
                    else if (task.Deadline < today)
                        Overdue.Add(vm);
                    else if (task.Deadline <= weekEnd)
                        Week.Add(vm);
                    else if (task.Deadline <= nextWeekEnd)
                        NextWeek.Add(vm);
                    else if (task.Deadline <= monthEnd)
                        NextMonth.Add(vm);
                    else
                        Later.Add(vm);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки дашборда: {ex.Message}");
            }
        }
    }
}
