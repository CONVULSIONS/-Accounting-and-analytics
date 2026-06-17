using AccountingAndAnalytics.Shared.ViewModels;
using AccountingAndAnalytics.Shared.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.TaskManager.ViewModels.PopUp
{
    public partial class AssignDealViewModel : ViewModelBase
    {
        private string _number;
        public string Number
        {
            get => _number;
            set { _number = value; OnPropertyChanged(); }
        }

        private string _period;
        public string Period
        {
            get => _period;
            set { _period = value; OnPropertyChanged(); }
        }

        private string _client;
        public string Client
        {
            get => _client;
            set { _client = value; OnPropertyChanged(); }
        }

        private string _realEstate;
        public string RealEstate
        {
            get => _realEstate;
            set { _realEstate = value; OnPropertyChanged(); }
        }

        private ObservableCollection<UserModel> _users { get; set; } = new();
        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                if (_users != value)
                    _users = value;
                OnPropertyChanged();
            }
        }

        private UserModel? _selectedUser;
        public UserModel? SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (_selectedUser != value)
                    _selectedUser = value;
                OnPropertyChanged();
            }
        }

        [RelayCommand]
        public void Assign() { }

        [RelayCommand]
        public void Close() { }
    }
}
