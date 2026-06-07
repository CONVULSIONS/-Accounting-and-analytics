using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using AccountingAndAnalytics.CRM.Services;
using AccountingAndAnalytics.CRM.Services.Repozitories;
using AccountingAndAnalytics.CRM.ViewModels.Elements;
using AccountingAndAnalytics.CRM.ViewModels.Pages;
using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.Shared.Interfaces.Repozitories;
using AccountingAndAnalytics.Shared.Models;
using AccountingAndAnalytics.Shared.Services;
using AccountingAndAnalytics.Shared.Services.Navigation;
using AccountingAndAnalytics.Shared.Services.Repozitories;
using AccountingAndAnalytics.Shared.ViewModels.Elements;
using AccountingAndAnalytics.Shared.ViewModels.Pages;
using AccountingAndAnalytics.Shared.ViewModels.Windows;
using AccountingAndAnalytics.Shared.Views.Pages;
using AccountingAndAnalytics.Shared.Views.Windows;
using AccountingAndAnalytics.TaskManager.Interfaces;
using AccountingAndAnalytics.TaskManager.Interfaces.Repozitories;
using AccountingAndAnalytics.TaskManager.Services;
using AccountingAndAnalytics.TaskManager.Services.Repozitories;
using AccountingAndAnalytics.TaskManager.ViewModels.Elements;
using AccountingAndAnalytics.TaskManager.ViewModels.Pages;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAndAnalytics
{
    public static class AppServiceCollection
    {
        public static IServiceCollection AddAppServices(this ServiceCollection services)
        {
            // сервисы остальные
            services.AddSingleton<ICurrentUserSession, CurrentUserSession>();            
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
            services.AddSingleton<IDialogService, DialogService>();

            // фабрики
            services.AddSingleton<IApplicationInListVmFactory, ApplicationInListVmFactory>();
            services.AddSingleton<IDealInListVmFactory, DealInListVmFactory>();
            services.AddSingleton<ITaskInListVmFactory, TaskInListVmFactory>();

            // репозитории
            services.AddSingleton<IDealRepozitory, ApiDealService>();
            services.AddSingleton<IApplicationRepozitory, ApiApplicationsRepository>();
            services.AddSingleton<IUserRepository, ApiUserRepository>();
            services.AddSingleton<ITaskService, ApiTaskService>();

            // главный контейнер
            // страницы приложения
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
            services.AddTransient<ProfileViewModel>();            

            // страницы контент домашней страницы
            services.AddSingleton<HomeViewModel>(); // глав
            services.AddTransient<DealPageViewModel>(); // сделки
            services.AddTransient<DealInListViewModel>(); // элемент сделка
            services.AddTransient<ApplicationPageViewModel>(); // заявки
            services.AddTransient<ApplicationInListViewModel>(); //элемент заявка
            services.AddTransient<DealTasksViewModel>(); // задачи

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
            services.AddSingleton<NavigationState>();
            services.AddSingleton<HttpClient>(_ => new HttpClient
            {
                BaseAddress = new Uri("http://127.0.0.1:8000")
            });

            return services;
        }
    }
}
