using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
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

        public ICommand CreateLandlordCommand { get; set; }
        public ICommand DeleteLandlordCommand { get; set; }
        public ICommand CreatePropertyCommand { get; set; }
        public ICommand EditLandlordCommand { get; set; }

        public LandlordsViewModel()
        {
            CreateLandlordCommand = new RelayCommand(CreateLandlord);
            DeleteLandlordCommand = new RelayCommand(DeleteLandlord);
            CreatePropertyCommand = new RelayCommand(CreateProperty);
            EditLandlordCommand = new RelayCommand(EditLandlord);

            Db = new();

            Db.Landlords.Load();
            AllLandlords = Db.Landlords.Local.ToObservableCollection();
        }

        public void CreateLandlord()
        {
            Landlord newLandlord = new("","","","","","","","");
            AllLandlords.Add(newLandlord);
            Db.SaveChanges();

            EditLandlord newWindow = new(newLandlord, Db);
            newWindow.Show();
        }

        public void DeleteLandlord()
        {
            if (SelectedLandlord == null) return;
            AllLandlords.Remove(SelectedLandlord);
            Db.SaveChanges();
        }

        public void CreateProperty()
        {
            if (SelectedLandlord == null) return;
            AddProperty newWindow = new(SelectedLandlord, Db);
            newWindow.Show();
        }

        public void EditLandlord()
        {
            if (SelectedLandlord == null) return;
            EditLandlord newWindow = new(SelectedLandlord, Db);
            newWindow.Show();
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
