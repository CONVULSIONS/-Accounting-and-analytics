using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.ViewModels;
using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingAndAnalytics.TaskManager.ViewModels.Pages
{
    public class DealPageViewModel : ViewModelBase, IAsyncInitializable
    {
        private readonly IDealRepozitory _dealsRepository;
        private readonly IDealInListVmFactory _factory;
        public string NumberTitle { get; } = "№";
        public string RealEstateTitle { get; } = "Недвижимость";
        public string ClientTitle { get; } = "Клиент";
        public string DeadlineTitle { get; } = "Срок до";
        public string TaskCountTitle { get; } = "Задач";

        public string Title { get; } = "Сделки";

        private ObservableCollection<DealInListViewModel> _deals { get; set; } = new();
        public ObservableCollection<DealInListViewModel> Deals 
        { 
            get => _deals; 
            set
            {
                if (_deals != value)
                {
                    _deals = value;
                    OnPropertyChanged();
                }
            }
        }

        public DealPageViewModel(IDealRepozitory dealsRepository, IDealInListVmFactory factory)
        {
            _dealsRepository = dealsRepository;
            _factory = factory;
        }

        public async Task InitializeAsync()
        {
            var dealList = await _dealsRepository.GetAllAsync();

            foreach (var deal in dealList)
            {
                _deals.Add(_factory.Create(deal));
            }
        }
    }
}
