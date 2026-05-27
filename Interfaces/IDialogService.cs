using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics.Interfaces
{
    public interface IDialogService
    {
        Task ShowInfoAsync(string message);
        Task ShowWarningAsync(string message);
        Task ShowErrorAsync(string message);
    }
}
