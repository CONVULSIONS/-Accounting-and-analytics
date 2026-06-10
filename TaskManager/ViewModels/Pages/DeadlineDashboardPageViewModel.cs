using AccountingAndAnalytics.Shared.ViewModels;
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
        public DeadlineDashboardPageViewModel()
        {
            // Просрочено
            _overdue.Add(new TaskInDashboardViewModel("ДА-06/2025-1", "З-001", "Подписание договора аренды", "01.06.2026"));
            _overdue.Add(new TaskInDashboardViewModel("ДА-06/2025-2", "З-002", "Передача документов клиенту", "03.06.2026"));
            _overdue.Add(new TaskInDashboardViewModel("ДА-06/2025-1", "З-003", "Согласование условий оплаты", "07.06.2026"));

            // Выполнено
            _completed.Add(new TaskInDashboardViewModel("ДА-05/2025-3", "З-004", "Проверка объекта недвижимости", "28.05.2026"));
            _completed.Add(new TaskInDashboardViewModel("ДА-05/2025-3", "З-005", "Оформление акта приёма-передачи", "30.05.2026"));

            // На этой неделе
            _week.Add(new TaskInDashboardViewModel("ДА-06/2025-4", "З-006", "Юридическая экспертиза договора", "12.06.2026"));
            _week.Add(new TaskInDashboardViewModel("ДА-06/2025-4", "З-007", "Согласование с финансовым отделом", "13.06.2026"));
            _week.Add(new TaskInDashboardViewModel("ДА-06/2025-5", "З-008", "Подготовка пакета документов", "14.06.2026"));

            // Через неделю
            _nextWeek.Add(new TaskInDashboardViewModel("ДА-06/2025-5", "З-009", "Встреча с представителем клиента", "18.06.2026"));
            _nextWeek.Add(new TaskInDashboardViewModel("ДА-06/2025-6", "З-010", "Регистрация договора в реестре", "20.06.2026"));

            // Через месяц
            _nextMonth.Add(new TaskInDashboardViewModel("ДА-07/2025-7", "З-011", "Плановая проверка объекта", "05.07.2026"));
            _nextMonth.Add(new TaskInDashboardViewModel("ДА-07/2025-7", "З-012", "Продление договора аренды", "10.07.2026"));

            // Более месяца
            _later.Add(new TaskInDashboardViewModel("ДА-08/2025-8", "З-013", "Инвентаризация помещений", "15.08.2026"));
            _later.Add(new TaskInDashboardViewModel("ДА-08/2025-8", "З-014", "Переоформление прав аренды", "01.09.2026"));
        }
    }
}
