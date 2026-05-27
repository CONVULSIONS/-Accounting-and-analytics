using AccountingAndAnalytics.Interfaces;
using AccountingAndAnalytics.Presentation.ViewModels.Elements;
using AccountingAndAnalytics.Presentation.ViewModels.Pages;
using AccountingAndAnalytics.Presentation.ViewModels.Windows;
using AccountingAndAnalytics.Presentation.Views.Elements;
using AccountingAndAnalytics.Presentation.Views.Pages;
using AccountingAndAnalytics.Presentation.Views.Windows;
using AccountingAndAnalytics.Services;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics
{
    public static class AppServiceCollection
    {
        public static IServiceCollection AddAppServices(this ServiceCollection services)
        {
            // синглтоны
            services.AddSingleton<ICurrentUserSession, CurrentUserSession>();
            services.AddSingleton<IUserRepository, FakeUserRepository>();
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<IDealsListManager, DealsListManager>();

            services.AddSingleton<IDealsRepozitory, FakeDealsRepozitory>();
            services.AddSingleton<IApplicationRepozitory, FakeApplicationRepository>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<Lazy<MainViewModel>>(provider =>
            new Lazy<MainViewModel>(() => provider.GetRequiredService<MainViewModel>()));

            services.AddSingleton<INavigationService, NavigationService>();

            

            // странички
            services.AddTransient<DealsViewModel>();
            services.AddTransient<DealViewModel>();

            services.AddTransient<ApplicationPageViewModel>();
            services.AddTransient<ApplicationInListViewModel>();

            // другое
            services.AddTransient<AuthorizationViewModel>();
            services.AddSingleton<SidebarViewModel>();


            return services;
        }
    }
}
