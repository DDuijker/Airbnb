using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.Windows;

namespace WpfApp1.ViewModels
{
    class LandlordsViewModel
    {
        public Landlord SelectedLandlord { get; set; }
        public virtual ObservableCollection<Landlord> AllLandlords { get; set; }
        private AirBnbContext Db { get; set; }

        public RelayCommand CreateLandlordCommand { get; set; }
        public RelayCommand DeleteLandlordCommand { get; set; }
        public RelayCommand CreatePropertyCommand { get; set; }
        public RelayCommand EditLandlordCommand { get; set; }

        public LandlordsViewModel()
        {
            CreateLandlordCommand = new(CreateLandlord);
            DeleteLandlordCommand = new(DeleteLandlord);
            CreatePropertyCommand = new(CreateProperty);
            EditLandlordCommand = new(EditLandlord);

            Db = new();

            Db.Landlords.Load();
            AllLandlords = Db.Landlords.Local.ToObservableCollection();
        }

        public void CreateLandlord()
        {
            Landlord newLandlord = new("","","","","","","","");
            AllLandlords.Add(newLandlord);
            Db.SaveChanges();

            EditLandlord newWindow = new(newLandlord);
            newWindow.Show();
            OnRequestClose();
        }

        public void DeleteLandlord()
        {
            AllLandlords.Remove(SelectedLandlord);
            Db.SaveChanges();
        }

        public void CreateProperty()
        {
            if (SelectedLandlord == null) return;
            AddProperty newWindow = new(SelectedLandlord);
            newWindow.Show();
        }

        public void EditLandlord()
        {
            if (SelectedLandlord == null) return;
            EditLandlord newWindow = new(SelectedLandlord);
            newWindow.Show();
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
