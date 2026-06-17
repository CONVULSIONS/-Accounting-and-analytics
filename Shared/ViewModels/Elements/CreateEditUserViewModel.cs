using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.ViewModels.Elements
{
    public partial class CreateEditUserViewModel : ViewModelBase
    {
        private readonly IUserService _service;
        private int? _userId = null;
        public bool IsEdit => _userId.HasValue;
        public string Title => IsEdit ? "Редактирование пользователя" : "Создание пользователя";
        public string ButtonTitle => IsEdit ? "СОХРАНИТЬ" : "СОЗДАТЬ";

        private string _firstName;
        public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(); } }

        private string _secondName;
        public string SecondName { get => _secondName; set { _secondName = value; OnPropertyChanged(); } }

        private string _surname;
        public string Surname { get => _surname; set { _surname = value; OnPropertyChanged(); } }

        private string _login;
        public string Login { get => _login; set { _login = value; OnPropertyChanged(); } }

        private string _password;
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }

        private RoleModel? _selectedRole;
        public RoleModel? SelectedRole { get => _selectedRole; set { _selectedRole = value; OnPropertyChanged(); } }

        private DepartmentModel? _selectedDepartment;
        public DepartmentModel? SelectedDepartment { get => _selectedDepartment; set { _selectedDepartment = value; OnPropertyChanged(); } }

        public ObservableCollection<RoleModel> Roles { get; } = new();
        public ObservableCollection<DepartmentModel> Departments { get; } = new();

        public CreateEditUserViewModel(IUserService service)
        {
            _service = service;
        }

        public async Task InitCreate()
        {
            _userId = null;
            await LoadReferences();
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(ButtonTitle));
        }

        public async Task InitEdit(UserModel user)
        {
            _userId = user.Id;
            await LoadReferences();
            FirstName = user.FirstName;
            SecondName = user.SecondName;
            Surname = user.Surname;
            Login = user.Login;
            SelectedRole = Roles.FirstOrDefault(r => r.Id == user.RoleId);
            SelectedDepartment = Departments.FirstOrDefault(d => d.Id == user.DepartmentId);
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(ButtonTitle));
        }

        private async Task LoadReferences()
        {
            var roles = await _service.GetRolesAsync();
            var departments = await _service.GetDepartmentsAsync();
            Roles.Clear();
            Departments.Clear();
            foreach (var r in roles) Roles.Add(r);
            foreach (var d in departments) Departments.Add(d);
        }

        [RelayCommand]
        private async Task Save()
        {
            if (IsEdit)
                await _service.EditAsync(_userId!.Value, FirstName, SecondName, Surname, Login, Password, SelectedRole!.Id, SelectedDepartment?.Id);
            else
                await _service.CreateAsync(FirstName, SecondName, Surname, Login, Password, SelectedRole!.Id, SelectedDepartment?.Id);
            DialogHost.Close("MainDialog");
        }

        [RelayCommand]
        private void Close() => DialogHost.Close("MainDialog");
    }
}
