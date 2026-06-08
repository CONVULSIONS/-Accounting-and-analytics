using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using AccountingAndAnalytics.Analytics.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingAndAnalytics.Shared.ViewModels.Pages
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly IAppNavigationService _navigation;
        public StatisticViewModel Statistic {  get; set; }
        public ProfileViewModel(IAppNavigationService navigation)
        {
            //_navigation = navigation;
            //BackCommand = new RelayCommand(Back);
            //Statistic = new StatisticViewModel();
            try
            {
                _navigation = navigation;
                BackCommand = new RelayCommand(Back);
                Statistic = new StatisticViewModel();
                Console.WriteLine("ProfileViewModel создан успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в ProfileViewModel: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public ICommand BackCommand { get; }
        private void Back()
        {
            _navigation.NavigateTo<HomeViewModel>();
        }
    }
}
