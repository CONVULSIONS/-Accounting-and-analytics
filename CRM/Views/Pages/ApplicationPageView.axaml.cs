using AccountingAndAnalytics.Interfaces;
using AccountingAndAnalytics.CRM.ViewModels.Pages;
using AccountingAndAnalytics.Services;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AccountingAndAnalytics.CRM.Views.Pages;

public partial class ApplicationPageView : UserControl
{
    public ApplicationPageView()
    {
        InitializeComponent();
        DataContext = new ApplicationPageViewModel(App.Services.GetRequiredService<IApplicationRepozitory>(), App.Services.GetRequiredService<IDealsRepozitory>());
    }
}