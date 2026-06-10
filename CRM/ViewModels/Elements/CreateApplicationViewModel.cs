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

namespace AccountingAndAnalytics.CRM.ViewModels.Elements
{
    public partial class CreateApplicationViewModel : ViewModelBase
    {
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
        public List<string> RealEstate { get; set; } = new();
        public CreateApplicationViewModel()
        {           
        }
        [RelayCommand]
        public async Task CloseCreateDialog()
        {
            DialogHost.Close("MainDialog");
        }
    }
}
