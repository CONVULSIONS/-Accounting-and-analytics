using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.ViewModels.Elements;
using AccountingAndAnalytics.Shared.Views.Elements;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Shared.ViewModels.Pages
{
    public partial class UserPageViewModel : ViewModelBase, IAsyncInitializable
    {
        private readonly IUserService _userService;
        private readonly IUserInListVmFactory _userFactory;
        private readonly ICreateEditUserVmFactory _createEditFactory;

        public string Title { get; set; } = "Пользователи";
        public ObservableCollection<UserInListViewModel> Users { get; set; } = new();

        public UserPageViewModel(IUserService userService, IUserInListVmFactory userFactory, ICreateEditUserVmFactory createEditFactory)
        {
            _userService = userService;
            _userFactory = userFactory;
            _createEditFactory = createEditFactory;
        }

        public async Task InitializeAsync()
        {
            Users.Clear();
            var users = await _userService.GetAllAsync();
            foreach (var user in users)
            {
                Users.Add(_userFactory.Create(user, async () =>
                {
                    Users.Clear();
                    await InitializeAsync();
                }));
            }
        }

        [RelayCommand]
        public async Task OpenCreateDialog()
        {
            var vm = await _createEditFactory.CreateAsync();
            var view = new CreateEditUserView { DataContext = vm };
            await DialogHost.Show(view, "MainDialog");
            await InitializeAsync();
        }
    }
}
