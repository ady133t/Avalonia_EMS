using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using Seetek_EMS.ViewModels;
using System;

namespace Seetek_EMS.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
            public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            var vm = serviceProvider.GetRequiredService<MainWindowViewModel>();
            vm.GetWindow = () => { return this;  };                                                                                
            DataContext = vm;

        }


        protected override void OnLoaded(RoutedEventArgs e)
        {
            base.OnLoaded(e);
            //this.Hide();
            //var ownerWindow = this;


            //var userLoginScreen = new UserLoginWindow();
            //userLoginScreen.Show();



        }

        private void MaximizeBtn(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void MinimizedBtn(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void CloseBtn(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }




        protected override void OnGotFocus(GotFocusEventArgs e)
        {
            base.OnGotFocus(e);


        }
        private void OnOpened(object? sender, EventArgs e)
        {

        }

        private bool _isDragging;
        private Point _startDragPoint;

        private void TitleBarPointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            {
                _isDragging = true;
                _startDragPoint = e.GetPosition(this);
            }
        }
        private void TitleBarPointerMoved(object sender, PointerEventArgs e)
        {
            if (_isDragging)
            {
                var currentPoint = e.GetPosition(this);
                this.Position = new PixelPoint(
                    this.Position.X + (int)(currentPoint.X - _startDragPoint.X),
                    this.Position.Y + (int)(currentPoint.Y - _startDragPoint.Y));
            }
        }

        private void TitleBarPointerReleased(object sender, PointerReleasedEventArgs e)
        {
            _isDragging = false;
        }
    }

}