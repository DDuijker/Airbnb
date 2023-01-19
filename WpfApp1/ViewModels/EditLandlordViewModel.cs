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
    class EditLandlordViewModel
    {
        public Landlord Landlord { get; set; }
        private AirBnbContext Db { get; set; }

        public ICommand SaveLandlordCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public EditLandlordViewModel(Landlord _landlord, AirBnbContext? _db = null)
        {
            SaveLandlordCommand = new RelayCommand(SaveLandlord);
            CancelCommand = new RelayCommand(Cancel);

            Landlord = _landlord;

            if (_db != null)
                Db = _db;
            else
            {
                Db = new();

                Landlord? lord = Db.Landlords.Where(_lord => _lord.Id == _landlord.Id).FirstOrDefault();
                if (lord != null)
                {
                    Landlord = lord;
                }
            }
        }

        public void SaveLandlord()
        {
            Db.SaveChanges();
            OnRequestClose();
        }

        public void Cancel()
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
