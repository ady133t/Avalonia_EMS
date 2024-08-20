using ActiproSoftware.Properties.Shared;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Seetek_EMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Seetek_EMS.ViewModels
{
    public partial class StationSelectWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _selectedItem;

        [ObservableProperty]
        private string _station = "Station";

   

        public ObservableCollection<string> Items { get; } = new()
        {
            "Preparation","SMD Top Reflow"

        };

        //public Action<string> OnOperationChanged;

        //private StationService _stationService;
        private IServiceProvider _serviceProvider;

        public StationSelectWindowViewModel()
        {
           
        }
            public StationSelectWindowViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            PropertyChanged += OnPropertyChanged;

            //Items = await _serviceProvider.GetRequiredService<HttpClient>().GetAsync("").Result.Content.ReadAsStringAsync();

           // LoadItems = async () => { await _serviceProvider.GetRequiredService<HttpClient>().GetAsync("").Result.Content.ReadAsStringAsync(); };
            SelectedItem = Items[0];
        }


        public async Task LoadItems()
        {
            await _serviceProvider.GetRequiredService<HttpClient>().GetAsync("").Result.Content.ReadAsStringAsync();
        }

        
        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedItem))
            {
                // Update the second property when the first property changes
               
                Debug.WriteLine("Changed");
            }
        }

        partial void OnSelectedItemChanged(string value)
        {
            var scanSNvm = _serviceProvider.GetRequiredService<ScanPageViewModel>();
            // scanSNvm.OnStationChanged("changed");
            scanSNvm.OnStationChanged("" + value);
        }
    }
}
