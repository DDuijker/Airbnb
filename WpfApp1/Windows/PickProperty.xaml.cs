﻿using System;
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
    /// Interaction logic for PickProperty.xaml
    /// </summary>
    public partial class PickProperty : Window
    {
        public PickProperty(Customer customer, AirBnbContext? _db = null)
        {
            InitializeComponent();

            PickPropertyViewModel Vm = new(customer, _db);
            Vm.RequestClose += (s, e) => this.Close();

            DataContext = Vm;

        }
    }
}
