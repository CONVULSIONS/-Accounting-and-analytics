using AccountingAndAnalytics.Shared.ViewModels;
using AccountingAndAnalytics.TaskManager.Interfaces.Repozitories;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.ViewModels.Elements
{
    public partial class CreateEditTaskViewModel : ViewModelBase
    {
        private readonly ITaskService _service;
        private int _dealId { get; set; }
        private int? _taskId { get; set; } = null;
        private bool IsEdit => _taskId.HasValue;
        public string Title => IsEdit ? "Редактирование задачи" : "Создание задачи";
        private string _taskTitle;
        public string TaskTitle
        {
            get => _taskTitle;
            set { _taskTitle = value; OnPropertyChanged(); }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }

        private DateOnly _deadline;

        public DateTime? Deadline
        {
            get => _deadline == DateOnly.MinValue ? null : _deadline.ToDateTime(TimeOnly.MinValue);
            set
            {
                _deadline = value.HasValue
                    ? DateOnly.FromDateTime(value.Value)
                    : DateOnly.MinValue;
                OnPropertyChanged();
            }
        }

        public CreateEditTaskViewModel(ITaskService service)
        {
            _service = service;
        }

        [RelayCommand]
        private async Task CloseCreateDialog()
        {
            DialogHost.Close("MainDialog");
        }

        [RelayCommand]
        private async Task Save()
        {
            if (IsEdit)
            {
                if (_taskId.HasValue)
                {
                    await _service.EditAsync(_taskId.Value, _taskTitle, _description, _deadline);
                }
            }
            else
                await _service.CreateAsync(TaskTitle, Description, _deadline, DateOnly.FromDateTime(DateTime.Now), _dealId);

            DialogHost.Close("MainDialog");
        }

        public void InitCreate(int dealId)
        {
            _dealId = dealId;
        }
        public async Task InitEdit(int taskId)
        {
            _taskId = taskId;
            var task = await _service.GetTaskByIdAsync(taskId);
            TaskTitle = task.Title;
            Description = task.Description;
            _deadline = task.Deadline;
        }
    }

}
