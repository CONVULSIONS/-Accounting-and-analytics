using AccountingAndAnalytics.Interfaces;
using CommunityToolkit.Mvvm.Input;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingAndAnalytics.Presentation.ViewModels.Windows
{
    public partial class AuthorizationViewModel : INotifyPropertyChanged
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        public Action? CloseWindowAction { get; set; }

        public string AuthTextblock { get; } = "АВТОРИЗАЦИЯ";
        public string LoginTextblock { get; } = "Логин";
        public string PassTextblock { get; } = "Пароль";
        public string AuthButtonText { get; } = "Войти";

        private string _loginText = string.Empty; 
        public string LoginText
        {
            get => _loginText;
            set
            {
                if (_loginText != value)
                {
                    _loginText = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _passText = string.Empty;
        public string PassText
        {
            get => _passText;
            set
            {
                if (_passText != value)
                {
                    _passText = value;
                    OnPropertyChanged();
                }
            }
        }

        public AuthorizationViewModel()
        {
            // пустой, только для превьюера
            AuthTextblock = "АВТОРИЗАЦИЯ";
            LoginTextblock = "Логин";
            PassTextblock = "Пароль";
            AuthButtonText = "Войти";
        }

        public AuthorizationViewModel(IAuthorizationService authorizationService, IDialogService dialogService, INavigationService navigationService)
        {
            _authorizationService = authorizationService;
            _dialogService = dialogService;
            _navigationService = navigationService;

            AutorizeAsyncCommand = new AsyncRelayCommand(AutorizeAsync);


        }

        public ICommand AutorizeAsyncCommand { get; }
        private async Task AutorizeAsync()
        {
            if (string.IsNullOrEmpty(_loginText) || string.IsNullOrEmpty(_passText))
            {
                await _dialogService.ShowWarningAsync("Введите логин и пароль!");
                return;
            }
            if (_authorizationService.AuthorizeUser(_loginText, _passText))
            {
                //await _dialogService.ShowInfoAsync("Успешная авторизация");
                _navigationService.NavigateToMain(this);
                CloseWindowAction?.Invoke();
                return ;
            }
            else
            {
                await _dialogService.ShowErrorAsync("Неверный логин или пароль");
                return;
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
