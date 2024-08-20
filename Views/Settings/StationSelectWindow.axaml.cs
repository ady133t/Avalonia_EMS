using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Seetek_EMS.Extensions;
using Seetek_EMS.Services;
using Seetek_EMS.ViewModels;
using System;

namespace Seetek_EMS.Views;

public partial class StationSelectWindow : Window
{

    private IServiceProvider _serviceProvider;
    private StationSelectWindowViewModel _vm;
    public StationSelectWindow() //only for preview
    {
        InitializeComponent();
    }

    public StationSelectWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _serviceProvider = serviceProvider;
        _vm = serviceProvider.GetRequiredService<StationSelectWindowViewModel>();

        DataContext = _vm;
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);


    }

    private async void OpLoaded(object? sender, RoutedEventArgs e)
    {

        //await _vm.LoadItems();
    }
}
