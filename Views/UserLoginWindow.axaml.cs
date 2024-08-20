using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

using Seetek_EMS.ViewModels;
using System;

namespace Seetek_EMS.Views;

public partial class UserLoginWindow : Window
{
    public UserLoginWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        var vm = serviceProvider.GetRequiredService<UserLoginWindowViewModel>();
        vm.OnRequestClose = () => { this.Close(); };
        DataContext = vm;
    }
}