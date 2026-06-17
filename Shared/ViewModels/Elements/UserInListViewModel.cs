using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Models;
using AccountingAndAnalytics.Shared.Views.Elements;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.ViewModels.Elements
{
    public partial class UserInListViewModel
    {
        private readonly IUserService _service;
        private readonly ICreateEditUserVmFactory _vmFactory;
        private Func<Task> _onRefresh;
        private UserModel _user;
        private int _userId;

        public string FullName { get; set; }
        public string Login { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }

        public UserInListViewModel(IUserService service, ICreateEditUserVmFactory vmFactory)
        {
            _service = service;
            _vmFactory = vmFactory;
        }

        public void Init(UserModel user, Func<Task> onRefresh)
        {
            _userId = user.Id;
            _user = user;
            _onRefresh = onRefresh;
            FullName = $"{user.Surname} {user.FirstName} {user.SecondName}";
            Login = user.Login;
            RoleName = user.RoleName;
            DepartmentName = user.DepartmentName;
        }

        [RelayCommand]
        private async Task Edit()
        {
            var editVm = await _vmFactory.EditAsync(_user);
            var editV = new CreateEditUserView { DataContext = editVm };

            await DialogHost.Show(editV, "MainDialog");
            await _onRefresh();
        }
        [RelayCommand]
        private async Task Delete()
        {
            await _service.DeleteAsync(_userId);
            await _onRefresh();
        }
    }
}
