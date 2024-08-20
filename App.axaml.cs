using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Seetek_EMS.Extensions;
using Seetek_EMS.ViewModels;
using Seetek_EMS.Views;

namespace Seetek_EMS
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override async void OnFrameworkInitializationCompleted()
        {

            // Register all the services needed for the application to run
            var collection = new ServiceCollection();
            collection.AddCommonServices();

            // Creates a ServiceProvider containing services from the provided IServiceCollection
            var services = collection.BuildServiceProvider();

            var vm = services.GetRequiredService<MainWindowViewModel>();


            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);



                var userLoginScreen = services.GetRequiredService<UserLoginWindow>();//new UserLoginWindow() { DataContext = new UserLoginWindowViewModel() };
                //userLoginScreen.DataContext = services.GetRequiredService<UserLoginWindowViewModel>();


                desktop.MainWindow = userLoginScreen;
                
                //userLoginScreen.DataContext =services.GetRequiredService<UserLoginWindowViewModel>();
                userLoginScreen.Show();

                //await userLoginScreen.Validate();


                //var mainWindow = new MainWindow
                //{
                //    DataContext = vm
                //};

                //desktop.MainWindow = mainWindow;

                //mainWindow.Show();
                //userLoginScreen.Close();

            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}