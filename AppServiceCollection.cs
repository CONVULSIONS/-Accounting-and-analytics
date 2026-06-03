using AccountingAndAnalytics.CRM.ViewModels.Elements;
using AccountingAndAnalytics.CRM.ViewModels.Pages;
using AccountingAndAnalytics.Shared.Views.Windows;
using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.Shared.Models;
using AccountingAndAnalytics.Shared.Services.Navigation;
using AccountingAndAnalytics.Shared.ViewModels.Elements;
using AccountingAndAnalytics.Shared.ViewModels.Pages;
using AccountingAndAnalytics.Shared.ViewModels.Windows;
using AccountingAndAnalytics.Shared.Views.Pages;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingAndAnalytics.Shared.Services;
using AccountingAndAnalytics.Shared.Services.Repozitories;
using AccountingAndAnalytics.Shared.Interfaces.Repozitories;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.CRM.Services;
using AccountingAndAnalytics.CRM.Services.Repozitories;

namespace AccountingAndAnalytics
{
    public static class AppServiceCollection
    {
        public static IServiceCollection AddAppServices(this ServiceCollection services)
        {
            // сервисы остальные
            services.AddSingleton<ICurrentUserSession, CurrentUserSession>();
            services.AddSingleton<IUserRepository, ApiUserRepository>();
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<IDealsListManager, DealsListManager>();

            // фабрики
            services.AddSingleton<IApplicationInListVmFactory, ApplicationInListVmFactory>();

            // репозитории
            services.AddSingleton<IDealsRepozitory, FakeDealsRepozitory>();
            services.AddSingleton<IApplicationRepozitory, ApiApplicationsRepository>();

            // главный контейнер
            // страницы приложения
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
            services.AddTransient<ProfileViewModel>();

            services.AddSingleton<NavigationState>();

            // страницы контент домашней страницы
            services.AddSingleton<HomeViewModel>();
            services.AddTransient<DealsViewModel>(); // сделки
            services.AddTransient<DealViewModel>();
            services.AddTransient<ApplicationPageViewModel>(); // заявки
            services.AddTransient<ApplicationInListViewModel>();


            // сервис навигации приложения
            services.AddSingleton<IAppNavigationService, AppNavigationService>();

            //сервис навигации домашней страницы
            services.AddSingleton<IHomeNavigationService>(provider =>
                new HomeNavigationService(
                    provider,
                    vm => provider.GetRequiredService<HomeViewModel>().CurrentPage = vm));

            // другое
            services.AddTransient<AuthorizationViewModel>();
            services.AddTransient<AuthorizationView>();
            services.AddSingleton<SidebarViewModel>();
            services.AddSingleton<HeaderViewModel>();


            return services;
        }
    }
}
