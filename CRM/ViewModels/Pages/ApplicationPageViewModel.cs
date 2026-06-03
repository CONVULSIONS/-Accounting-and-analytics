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

namespace AccountingAndAnalytics.CRM.ViewModels.Pages
{
    public class ApplicationPageViewModel : ViewModelBase
    {
        private readonly IApplicationRepozitory _applicationsRepozitory;
        private readonly IDealsRepozitory _dealsRepository;

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

        public ApplicationPageViewModel(IApplicationRepozitory applicationsRepozitory, IDealsRepozitory dealsRepozitory)
        {
            _applicationsRepozitory = applicationsRepozitory;
            _dealsRepository = dealsRepozitory;
            AddApplicationCommand = new RelayCommand(AddApplication);
            ApplicationToDealCommand = new RelayCommand(ApplicationToDeal);
            foreach (var application in _applicationsRepozitory.GetApplication())
            _applications.Add(new ApplicationInListViewModel(application));
        }

        private void AddApplication()
        {
            var newApplication = _applicationsRepozitory.AddApplication("я", "новая", "заявка");
            _applications.Add(new ApplicationInListViewModel(newApplication));
        }

        private void ApplicationToDeal()
        {
            if (_applications.Count > 0)
            {
                var app = _applicationsRepozitory.GetApplication().Last();
                var deal = _dealsRepository.ApplicationToDeal(app);
                _applicationsRepozitory.RemoveApplication(app);

                var appVM = _applications.FirstOrDefault(a => a.Id == app.Id);
                if (appVM != null) _applications.Remove(appVM);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
