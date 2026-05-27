using AccountingAndAnalytics.Interfaces;
using AccountingAndAnalytics.Presentation.ViewModels.Pages;
using AccountingAndAnalytics.Services;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AccountingAndAnalytics.Presentation.Views.Pages;

public partial class DealsView : UserControl
{
    public DealsView()
    {
        InitializeComponent();
        DataContext = new DealsViewModel(App.Services.GetRequiredService<IDealsRepozitory>());
    }
}