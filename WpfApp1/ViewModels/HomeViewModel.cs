using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
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
        public ICommand ShowLandlordsCommand { get; set; }
        public ICommand ShowPropertiesCommand { get; set; }
        public ICommand ShowCustomersCommand { get; set; }

        public HomeViewModel()
        {
            ShowLandlordsCommand = new RelayCommand(ShowLandlords);
            ShowPropertiesCommand = new RelayCommand(ShowProperties);
            ShowCustomersCommand = new RelayCommand(ShowCustomers);
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

        public void ShowCustomers()
        {
            Customers newWindow = new();
            newWindow.Show();
        }
    }
}
