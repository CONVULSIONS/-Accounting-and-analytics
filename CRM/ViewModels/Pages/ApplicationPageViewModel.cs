using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AccountingAndAnalytics.Shared.ViewModels;
using AccountingAndAnalytics.CRM.ViewModels.Elements;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using Microsoft.Extensions.DependencyInjection;
using AccountingAndAnalytics.CRM.Interfaces;

namespace AccountingAndAnalytics.CRM.ViewModels.Pages
{
    public class ApplicationPageViewModel : ViewModelBase, IAsyncInitializable
    {
        private readonly IApplicationInListVmFactory _factory;
        private readonly IApplicationRepozitory _applicationsRepozitory;

        private ObservableCollection<ApplicationInListViewModel> _applications { get; set; } = new();
        public ObservableCollection<ApplicationInListViewModel> Applications
        {
            get => _applications;
            set
            {
                if (_applications != value)
                {
                    _applications = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand AddApplicationCommand { get; }
        public ICommand ApplicationToDealCommand { get; }

        public ApplicationPageViewModel(IApplicationRepozitory applicationsRepository, IApplicationInListVmFactory factory)
        {
            _applicationsRepozitory = applicationsRepository;
            _factory = factory;
            //AddApplicationCommand = new RelayCommand(AddApplication);
            //ApplicationToDealCommand = new RelayCommand(ApplicationToDeal);

            //var appList = _applicationsRepozitory.GetAllAsync();
            //foreach (var application in appList)
            //_applications.Add(new ApplicationInListViewModel(application));
        }

        public async Task InitializeAsync()
        {
            var appList = await _applicationsRepozitory.GetAllAsync();

            foreach (var app in appList)
            {                
                _applications.Add(_factory.Create(app));
            }
        }

        //private void AddApplication()
        //{
        //    var newApplication = _applicationsRepozitory.AddApplication("я", "новая", "заявка");
        //    _applications.Add(new ApplicationInListViewModel(newApplication));
        //}

        //private void ApplicationToDeal()
        //{
        //    if (_applications.Count > 0)
        //    {
        //        var app = _applicationsRepozitory.GetApplication().Last();
        //        var deal = _dealsRepository.ApplicationToDeal(app);
        //        _applicationsRepozitory.RemoveApplication(app);

        //        var appVM = _applications.FirstOrDefault(a => a.Id == app.Id);
        //        if (appVM != null) _applications.Remove(appVM);
        //    }
        //}
    }
}
