using AccountingAndAnalytics.CRM.Models.Deals;
using AccountingAndAnalytics.CRM.Views.Elements;
using AccountingAndAnalytics.TaskManager.Interfaces.Factory;
using AccountingAndAnalytics.TaskManager.Interfaces.Repozitories;
using AccountingAndAnalytics.TaskManager.Models;
using AccountingAndAnalytics.TaskManager.Views.Elements;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.ViewModels.Elements
{
    public partial class TaskInListViewModel
    {
        private readonly ICreateEditTaskVmFactory _vmFactory;
        private readonly ITaskService _service;
        private Func<Task> _onRefresh;
        private int _taskId;
        public bool IsCompleted { get; private set; } = false;
        public int Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedDateLabel { get; set; } = "Назначена:";
        public string CreatedDate { get; set; }
        public string DeadlineLabel { get; set; } = "Срок:";
        public string Deadline { get; set; }
        public string Status { get; set; }
        public string MarkAsDoneLabel { get; set; } = "Отметить готовой";
        public TaskInListViewModel(ICreateEditTaskVmFactory factory, ITaskService service)
        {
            _vmFactory = factory;
            _service = service;         
        }

        public void Init(TaskModel task, Func<Task> onRefresh)
        {
            _taskId = task.Id;
            _onRefresh = onRefresh;
            Number = task.Number;
            Title = task.Title;
            Description = task.Description;
            Deadline = task.Deadline.ToString();
            CreatedDate = task.Created.ToString();
            Status = task.StatusName;
            if (task.StatusName == "выполнена")
                IsCompleted = true;
        }

        [RelayCommand]
        private async Task MarkReadyAsync()
        {
            await _service.MarkReadyAsync(_taskId);
            await _onRefresh();
        }
        [RelayCommand]
        private async Task EditAsync()
        {
            var editVm = await _vmFactory.EditAsync(_taskId);
            var editV = new CreateEditTaskView { DataContext = editVm };

            await DialogHost.Show(editV, "MainDialog");
            await _onRefresh();
        }
        [RelayCommand]
        private async Task DeleteAsync()
        {
            await _service.DeleteAsync(_taskId);
            await _onRefresh();
        }
    }
}
