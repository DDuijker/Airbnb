using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class AddPropertyViewModel
    {
        public Property NewProperty { get; set; }
        public Landlord SelectedLandlord { get; set; }

        private AirBnbContext Db { get; set; }

        public ICommand SavePropertyCommand { get; set; }
        public ICommand CancelPropertyCommand { get; set; }

        public AddPropertyViewModel(Landlord _landlord, AirBnbContext? _db = null)
        {
            if (_db == null)
                Db = new();
            else
                Db = _db;

            SavePropertyCommand = new RelayCommand(SaveProperty);
            CancelPropertyCommand = new RelayCommand(CancelPropery);

            SelectedLandlord = _landlord;
            NewProperty = new("","","","",0,0,0,0,"","","");
        }

        public void SaveProperty()
        {
            Db.Properties.Add(NewProperty);
            Db.SaveChanges();

            SelectedLandlord.Properties.Add(NewProperty);
            NewProperty.Landlord = SelectedLandlord;
            Db.SaveChanges();

            OnRequestClose();
        }

        public void CancelPropery()
        {
            OnRequestClose();
        }

        public event EventHandler RequestClose;
        protected void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
