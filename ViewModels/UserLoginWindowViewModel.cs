using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Seetek_EMS.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seetek_EMS.ViewModels
{
    public partial class UserLoginWindowViewModel : ViewModelBase
    {

        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _errorMsg;

        [ObservableProperty]
        private bool _passCheck = true;

        public Action OnRequestClose;


        //private IWindowService _windowService;
        private UserLoginWindow _userLoginWindow;
        //public UserLoginWindowViewModel()
        //{

        //}

        private IServiceProvider _serviceProvider;

        public UserLoginWindowViewModel()
        {

        }
        public UserLoginWindowViewModel(IServiceProvider serviceProvider)
        {
            //_userLoginWindow = userLoginWindow;
            _serviceProvider = serviceProvider;
            Username = "test";
            Password = "test";

            PropertyChanged += OnPropertyChanged;
        }


        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Username))
            {
                // Update the second property when the first property changes
                Debug.WriteLine("Changed");
            }
        }

        [RelayCommand]
        private void Login()
        {
            //_windowService.CloseCurrentWindow();

            if (Username.ToLower().Equals("test") && Password.Equals("test"))
            {
                var MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                MainWindow.Show();
                //_userLoginWindow.Close();
                OnRequestClose();
                //window.Close();
            }

            else
            {
                ErrorMsg = "* Wrong Username or Password";
            }


        }
    }
}
