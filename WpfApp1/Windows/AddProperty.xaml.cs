using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Interaction logic for AddProperty.xaml
    /// </summary>
    public partial class AddProperty : Window
    {
        public AddProperty(Landlord SelectedLandlord, AirBnbContext? _db = null)
        {
            InitializeComponent();

            AddPropertyViewModel Vm = new(SelectedLandlord, _db);
            Vm.RequestClose += (s, e) => this.Close();

            DataContext = Vm;
        }
    }
}
