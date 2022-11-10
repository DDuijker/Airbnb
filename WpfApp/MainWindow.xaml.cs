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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Voornaam_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            ///check that the textboxes aren't empty
            ///check that the name doesn't already exist
            if (!string.IsNullOrWhiteSpace(firstName.Text) && !string.IsNullOrWhiteSpace(lastName.Text)
                && !listBox.Items.Contains(firstName.Text + " " + lastName.Text))
            {
                ///add the name to the listbox
                listBox.Items.Add(firstName.Text + " " + lastName.Text);
                ///clear textboxes
                firstName.Text = "";
                lastName.Text = "";

            }
            
          

        }
    }
}
