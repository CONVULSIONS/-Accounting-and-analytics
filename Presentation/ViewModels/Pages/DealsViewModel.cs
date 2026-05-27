using AccountingAndAnalytics.Interfaces;
using AccountingAndAnalytics.Models;
using AccountingAndAnalytics.Services;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountingAndAnalytics.Presentation.ViewModels.Elements;

namespace AccountingAndAnalytics.Presentation.ViewModels.Pages
{
    public class DealsViewModel : ViewModelBase
    {
        private readonly IDealsRepozitory _dealsRepository;
      
        private ObservableCollection<DealViewModel> _deals { get; set; } = new();
        public ObservableCollection<DealViewModel> Deals 
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
        public ICommand AddDealCommand { get; }

        public DealsViewModel(IDealsRepozitory dealsRepository)
        {
            _dealsRepository = dealsRepository;
            AddDealCommand = new RelayCommand(AddDeal);
            foreach (var deal in _dealsRepository.GetDeals())
            _deals.Add(new DealViewModel(deal));
        }

        private void AddDeal()
        {
            var newDeal = _dealsRepository.AddDeal("я", "новая", "сделка", new DateTime(2026, 01, 01));
            _deals.Add(new DealViewModel(newDeal));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
