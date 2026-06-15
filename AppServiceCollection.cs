using AccountingAndAnalytics.CRM.Interfaces;
using AccountingAndAnalytics.CRM.Interfaces.Repozitories;
using AccountingAndAnalytics.CRM.Services;
using AccountingAndAnalytics.CRM.Services.Repozitories;
using AccountingAndAnalytics.CRM.ViewModels.Elements;
using AccountingAndAnalytics.CRM.ViewModels.Pages;
using AccountingAndAnalytics.Shared.Interfaces;
using AccountingAndAnalytics.Shared.Interfaces.Navigation;
using AccountingAndAnalytics.Shared.Models;
using AccountingAndAnalytics.Shared.Services;
using AccountingAndAnalytics.Shared.Services.Navigation;
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
using AccountingAndAnalytics.Analytics.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using AccountingAndAnalytics.CRM.Interfaces.Api;
using AccountingAndAnalytics.CRM.Services.Api;

namespace AccountingAndAnalytics
{
    public static class AppServiceCollection
    {
        public static IServiceCollection AddAppServices(this ServiceCollection services)
        {
            // сервисы 
            services.AddSingleton<CurrentUserService>();            
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
            services.AddSingleton<IDialogService, DialogService>();
            

            // фабрики
            services.AddSingleton<IApplicationInListVmFactory, ApplicationInListVmFactory>();
            services.AddSingleton<IDealInListVmFactory, DealInListVmFactory>();
            services.AddSingleton<ITaskInListVmFactory, TaskInListVmFactory>();
            services.AddSingleton<ICreateEditTaskVmFactory, CreateEditTaskVmFactory>();            
            services.AddSingleton<ICommentVmFactory, CommentVmFactory>();
            services.AddSingleton<ITaskInDashboardVmFactory, TaskInDashboardVmFactory>();

            // репозитории
            services.AddSingleton<IDealRepozitory, ApiDealService>();
            services.AddSingleton<IApplicationService, ApiApplicationService>();
            services.AddSingleton<IUserService, ApiUserService>();
            services.AddSingleton<ITaskService, ApiTaskService>();
            services.AddSingleton<IRealEstateService, ApiRealEstateService>();
            services.AddSingleton<ICommentService, ApiCommentService>();

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
            services.AddTransient<DeadlineDashboardPageViewModel>(); // сроки
            // попапы
            services.AddTransient<CreateApplicationViewModel>();
            services.AddTransient<CreateEditTaskViewModel>();
            // стата
            services.AddSingleton<StatisticViewModel>();

            // элементы
            services.AddTransient<TaskInListViewModel>();
            services.AddTransient<CommentViewModel>();
            services.AddTransient<TaskInDashboardViewModel>();

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
            services.AddTransient<HeaderViewModel>();
            services.AddSingleton<NavigationState>();
            //services.AddSingleton<HttpClient>(_ => new HttpClient
            //{
            //    BaseAddress = new Uri("http://127.0.0.1:8000")
            //});


            services.AddTransient<AuthHeaderHandler>();
            services.AddSingleton<HttpClient>(provider =>
            {
                var handler = new AuthHeaderHandler(
                    provider.GetRequiredService<CurrentUserService>())
                {
                    InnerHandler = new HttpClientHandler()
                };
                return new HttpClient(handler) { BaseAddress = new Uri("http://127.0.0.1:8000") };
            });

            return services;
        }
    }
}
