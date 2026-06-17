using AccountingAndAnalytics.CRM.Models.Applications;
using AccountingAndAnalytics.Shared.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialogHostAvalonia;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using AccountingAndAnalytics.CRM.Models;
using AccountingAndAnalytics.CRM.Interfaces.Api;
using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;

namespace AccountingAndAnalytics.CRM.ViewModels.Elements
{
    public partial class CreateApplicationViewModel : ViewModelBase
    {
        private readonly IApplicationService _appService;
        private readonly IRealEstateService _realService;
        private string _descriptionText { get; set; } = string.Empty;
        public string DescriptionText 
        { 
            get => _descriptionText; 
            set
            {
                if (_descriptionText != value)
                {
                    _descriptionText = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _surnameText { get; set; }
        public string SurnameText
        {
            get => _surnameText;
            set
            {
                if (_surnameText != value)
                {
                    _surnameText = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _firstNameText { get; set; }
        public string FirstNameText
        {
            get => _firstNameText;
            set
            {
                if (_firstNameText != value)
                {
                    _firstNameText = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _secondNameText { get; set; }
        public string SecondNameText
        {
            get => _secondNameText;
            set
            {
                if (_secondNameText != value)
                {
                    _secondNameText = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _phonText { get; set; }
        public string PhonText
        {
            get => _phonText;
            set
            {
                if (_phonText != value)
                {
                    _phonText = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Title { get; } = "НОВАЯ ЗАЯВКА";
        public string DescriptionTitle { get; } = "ПРИМЕЧАНИЯ";
        public string ClientTitle { get; } = "КЛИЕНТ";
        public string SurnameTitle { get; } = "ФАМИЛИЯ";
        public string FirstNameTitle { get; } = "ИМЯ";
        public string SecondNameTitle { get; } = "ОТЧЕСТВО";
        public string PhonTitle { get; } = "НОМЕР ТЕЛЕФОНА";
        public string RealEstateTitle { get; } = "ОБЪЕКТ НЕДВИЖИМОСТИ";
        public string btnCreateTitle { get; } = "СОЗДАТЬ";
        private ObservableCollection<RealEstateModel> _realEstate { get; set; } = new();
        public ObservableCollection<RealEstateModel> RealEstate
        {
            get => _realEstate;
            set
            {
                if (_realEstate != value)
                    _realEstate = value;
                OnPropertyChanged();
            }
        }
        private RealEstateModel? _selectedRealEstate;
        public RealEstateModel? SelectedRealEstate
        {
            get => _selectedRealEstate;
            set
            {
                if (_selectedRealEstate != value)
                    _selectedRealEstate = value;
                    OnPropertyChanged();
            }
        }
        public CreateApplicationViewModel(IApplicationService appService, IRealEstateService realService)
        {          
            _appService = appService;
            _realService = realService;
            _ = Load();
        }
        
        private async Task Load()
        {
            var realEstateList = await _realService.GetRealEstateAsync();
            foreach (var item in realEstateList)
            {
                _realEstate.Add(item);
            }
        }
        [RelayCommand]
        private async Task CloseCreateDialog()
        {
            DialogHost.Close("MainDialog");
        }
        [RelayCommand]
        private async Task Create()
        {
            await _appService.Create(_firstNameText, _secondNameText, _surnameText, _selectedRealEstate.Id, _selectedRealEstate.Name, new DateOnly(2017, 11, 13));
        }
    }
}
