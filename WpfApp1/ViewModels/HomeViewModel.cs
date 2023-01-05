using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Windows;

namespace WpfApp1.ViewModels
{
    class HomeViewModel
    {
        public RelayCommand ShowLandlordsCommand { get; set; }
        public RelayCommand ShowPropertiesCommand { get; set; }

        public HomeViewModel()
        {
            ShowLandlordsCommand = new(ShowLandlords);
            ShowPropertiesCommand = new(ShowProperties);
        }

        public void ShowLandlords()
        {
            Landlords newWindow = new();
            newWindow.Show();
        }

        public void ShowProperties()
        {
            Properties newWindow = new();
            newWindow.Show();
        }
    }
}
