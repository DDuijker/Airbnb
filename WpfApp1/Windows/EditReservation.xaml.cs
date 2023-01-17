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
    /// Interaction logic for EditReservation.xaml
    /// </summary>
    public partial class EditReservation : Window
    {
        public EditReservation(Reservation _reservation)
        {
            InitializeComponent();

            EditReservationViewModel Vm = new(_reservation);
            Vm.RequestClose += (s, e) => this.Close();

            DataContext = Vm;
        }
    }
}
