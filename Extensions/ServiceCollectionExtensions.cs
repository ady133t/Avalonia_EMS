using Microsoft.Extensions.DependencyInjection;
using Seetek_EMS.Services;
using Seetek_EMS.ViewModels;
using Seetek_EMS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Seetek_EMS.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddCommonServices(this IServiceCollection collection)
        {

            collection.AddTransient<MainWindow>();
            collection.AddTransient<MainWindowViewModel>();

            collection.AddTransient<UserLoginWindow>();
            collection.AddTransient<UserLoginWindowViewModel>();

            //collection.AddSingleton<StationService>();
            collection.AddTransient<StationSelectWindow>();
            collection.AddTransient<StationSelectWindowViewModel>();

            collection.AddTransient<ScanPageView>();
            collection.AddSingleton<ScanPageViewModel>();

            collection.AddTransient<RegisterSNPageView>();
            collection.AddTransient<RegisterSNPageViewModel>();

            // Register IServiceProvider itself
            collection.AddSingleton<IServiceProvider>(provider => provider);

            collection.AddTransient<HttpClient>(factory => new HttpClient() { BaseAddress = new Uri("") });

            //collection.AddTransient<UserLoginWindowViewModel>(sp => new UserLoginWindowViewModel(sp.GetRequiredService<UserLoginWindow>()));

            //collection.AddTransient<IWindowService,WindowService>(sp => new WindowService(sp.GetRequiredService<UserLoginWindow>()));

            //collection.AddTransient<LoginPageViewModel>();
        }
    }
}
