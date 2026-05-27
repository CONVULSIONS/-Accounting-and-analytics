using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AccountingAndAnalytics.Presentation.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using AccountingAndAnalytics.Presentation.ViewModels.Windows;
using AccountingAndAnalytics.Presentation.Views;
using System;

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
            var services = new ServiceCollection();
            services.AddAppServices();
            Services = services.BuildServiceProvider();

            //var authorizationViewModel = servicesProvider.GetRequiredService<AuthorizationViewModel>();
            //var authorizationViewModel = Services.GetRequiredService<MainViewModel>();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var authorizationViewModel =
                    Services.GetRequiredService<AuthorizationViewModel>();

                var authorizationWindow =
                    new AuthorizationWindow
                    {
                        DataContext = authorizationViewModel
                    };

                authorizationViewModel.CloseWindowAction =
                    authorizationWindow.Close;

                desktop.MainWindow = authorizationWindow;
                //desktop.MainWindow = new MainWindow
                //{
                //    DataContext = authorizationViewModel,
                //};
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}