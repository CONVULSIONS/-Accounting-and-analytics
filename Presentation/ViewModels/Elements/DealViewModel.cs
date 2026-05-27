using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountingAndAnalytics.Interfaces;
using CommunityToolkit.Mvvm.Input;
using AccountingAndAnalytics.Models;

namespace AccountingAndAnalytics.Presentation.ViewModels.Elements
{
    public class DealViewModel
    {
        public string Number { get; set; }
        public string RealEstateName { get; set; }
        public string ClientName { get; set; }
        public string Deadline { get; set; }
        public string Status { get; set; }
        public ObservableCollection<DealTask> Tasks { get; }

        private bool _isExpanded = false;
        public bool IsExpanded
        {
            get => _isExpanded;
            set { _isExpanded = value; OnPropertyChanged(); }
        }

        public ICommand ToggleExpandCommand { get; }

        public DealViewModel(Deal deal)
        {
            ToggleExpandCommand = new RelayCommand(() => IsExpanded = !IsExpanded);
            Number = deal.Number;
            ClientName = deal.ClientName;
            RealEstateName = deal.RealEstateName;
            Deadline = deal.Deadline.ToString();
            Status = deal.Status;
            Tasks = deal.Tasks;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
