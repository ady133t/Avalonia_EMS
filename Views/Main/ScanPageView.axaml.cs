using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace Seetek_EMS.Views;

public partial class ScanPageView : UserControl
{
    public ScanPageView()
    {
        InitializeComponent();
       

    }


    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        //this.Hide();
        //var ownerWindow = this;


        //var userLoginScreen = new UserLoginWindow();
        //userLoginScreen.Show();

        SNText.Focus();

    }

    protected override void OnGotFocus(GotFocusEventArgs e)
    {
        base.OnGotFocus(e);
        SNText.Focus();
    }

    private void PassBtn(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new PassFailWindow().Show();
    }
}