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
using AccountingAndAnalytics.CRM.Views.Elements;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using Microsoft.Extensions.DependencyInjection;
using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.Shared.Interfaces;
using Avalonia.Controls;
using DialogHostAvalonia;

namespace AccountingAndAnalytics.CRM.ViewModels.Pages
{
    public partial class ApplicationPageViewModel : ViewModelBase, IAsyncInitializable
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

        public ApplicationPageViewModel(IApplicationRepozitory applicationsRepository, IApplicationInListVmFactory factory)
        {
            _applicationsRepozitory = applicationsRepository;
            _factory = factory;
        }

        public async Task InitializeAsync()
        {
            var appList = await _applicationsRepozitory.GetAllAsync();

            foreach (var app in appList)
            {
                _applications.Add(_factory.Create(app));
            }
        }

        [RelayCommand]
        public async Task OpenCreateDialog()
        {
            var createVm = new CreateApplicationViewModel();
            var createV = new CreateApplicationView { DataContext = createVm };

            await DialogHost.Show(createV, "MainDialog");
            _applications.Clear();
            await InitializeAsync();
        }
    }
}
