using AccountingAndAnalytics.Shared.Interfaces;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccountingAndAnalytics.Shared.Services
{
    public class DialogService : IDialogService
    {
        public async Task ShowInfoAsync(string message)
        {
            var messageBox = MessageBoxManager.GetMessageBoxStandard(
                "Оповещение",
                $"{message}",
                ButtonEnum.Ok,
                Icon.Info
                );
            await messageBox.ShowAsync();
        }
        public async Task ShowWarningAsync(string message)
        {
            var messageBox = MessageBoxManager.GetMessageBoxStandard(
                "Предупреждение",
                $"{message}",
                ButtonEnum.Ok,
                Icon.Warning
                );
            await messageBox.ShowAsync();
        }
        public async Task ShowErrorAsync(string message)
        {
            var messageBox = MessageBoxManager.GetMessageBoxStandard(
                "Ошибка",
                $"{message}",
                ButtonEnum.Ok,
                Icon.Error
                );
            await messageBox.ShowAsync();
        }
    }
}
