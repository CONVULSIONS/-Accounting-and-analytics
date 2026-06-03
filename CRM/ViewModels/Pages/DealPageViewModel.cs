using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using AccountingAndAnalytics.CRM.ViewModels.Elements;
using AccountingAndAnalytics.Shared.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingAndAnalytics.CRM.ViewModels.Pages
{
    public class DealPageViewModel : ViewModelBase, IAsyncInitializable
    {
        private readonly IDealRepozitory _dealsRepository;
        private readonly IDealInListVmFactory _factory;
        public string Title { get; } = "МОИ СДЕЛКИ";

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
