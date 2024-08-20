using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Seetek_EMS.ViewModels
{
    public partial class ScanPageViewModel : ViewModelBase
    {

        [ObservableProperty]
        private string _operation = "Test";

        public Action<string> OnStationChanged;

        public ScanPageViewModel()
        {

        }

        public ScanPageViewModel(IServiceProvider serviceProvider)
        {
           
            OnStationChanged = (data) => {
                Operation = data;
            };


        }


    }
}
