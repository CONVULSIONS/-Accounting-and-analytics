using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AccountingAndAnalytics.Shared.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using AccountingAndAnalytics.Shared.Views;
using System;
using AccountingAndAnalytics.Shared.ViewModels.Windows;
//using LiveChartsCore;
//using LiveChartsCore.SkiaSharpView;

namespace AccountingAndAnalytics
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
        public static IServiceProvider Services { get; private set; }

        public override void OnFrameworkInitializationCompleted()
        {
            //LiveCharts.Configure(config => config.AddSkiaSharp());

            var services = new ServiceCollection();
            services.AddAppServices();
            Services = services.BuildServiceProvider();

            var mainViewModel = Services.GetRequiredService<MainViewModel>();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = mainViewModel,                
                }; 
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}