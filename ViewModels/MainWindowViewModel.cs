using Avalonia.Media;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Seetek_EMS.Views;
using System.Collections.ObjectModel;
using System;
using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace Seetek_EMS.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
       

        [ObservableProperty]
        private ViewModelBase? _currentPage;


        private MainWindow _mainWindow;

        [ObservableProperty]
        private bool _isPaneOpen = false;

        [ObservableProperty]
        private Thickness _margin = new Thickness(0, 0, 0, 0);

        public Func<Window> GetWindow;
       

        public ObservableCollection<ListItemTemplate> Items { get; } = new()
        {
            new ListItemTemplate(typeof(ScanPageViewModel),"home_regular"),
            new ListItemTemplate(typeof(RegisterSNPageViewModel),"cursor_hover_regular"),
            //new ListItemTemplate(typeof(ButtonPageViewModel) , "cursor_hover_regular")
        };

        [ObservableProperty]
        private ListItemTemplate? _selectedItemList;

        public MainWindowViewModel()
        {
            //CurrentPage = new LoginPageViewModel(this);
            SelectedItemList = Items[0];
        }
        private IServiceProvider _serviceProvider ;
        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            SelectedItemList = Items[0];

        }

        partial void OnIsPaneOpenChanged(bool value)
        {
            //if (value)
            //{
            //    Margin = new Thickness(0, 0, 0, 0);
            //}

            //else
            //    Margin = new Thickness(15, 0, 0, 0);
        }

        partial void OnSelectedItemListChanged(ListItemTemplate? value)
        {
            if (value is null) return;
            var instance = new Object();
            //if (value.ModelType == typeof(ScanPageViewModel))
            //{
            //    object[] args = { _serviceProvider};
            //    instance = _serviceProvider.GetService(typeof(ScanPageViewModel));
            //}
            //else
            if (_serviceProvider == null)
            instance = Activator.CreateInstance(value.ModelType);

            else
            instance = _serviceProvider.GetService(value.ModelType);

            if (instance == null) return;
            CurrentPage = (ViewModelBase)instance;
        }

        [RelayCommand]
        private void OpenStation()
        {
            var StationWindow = _serviceProvider.GetRequiredService<StationSelectWindow>();
            StationWindow.ShowDialog(GetWindow());

        }

        [RelayCommand]
        private void Exit()
        {
            _mainWindow.Close();
        }

        [RelayCommand]
        private void OpenPane()
        {
            IsPaneOpen = !IsPaneOpen;
        }

    }

    public class ListItemTemplate
    {
        public ListItemTemplate(Type type, string iconKey)
        {
            ModelType = type;
            Label = type.Name.Replace("PageViewModel", "");
            Application.Current!.TryFindResource(iconKey, out var res);
            ListItemIcon = (Geometry)res!;
            //Margin = new Thickness(15, 0, 0, 1);
        }


        public string Label { get; }

        public Type ModelType { get; }
        public Geometry ListItemIcon { get; }

        // public Thickness Margin { get; } = new Thickness(15,0,0,1);
    }
}
