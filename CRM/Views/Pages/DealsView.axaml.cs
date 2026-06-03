using AccountingAndAnalytics.CRM.ViewModels.Pages;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;

namespace AccountingAndAnalytics.CRM.Views.Pages;

public partial class DealsView : UserControl
{
    public DealsView()
    {
        InitializeComponent();
        DataContext = new DealsViewModel(App.Services.GetRequiredService<IDealsRepozitory>());
    }
}