using AirBnB.Models;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AirBnB.ViewModels
{
    public class LandlordViewModel
    {
        public Landlord Landlord { get; set; }
        public Landlord SelectedLandlord { get; set; }
        public RelayCommand DeleteLandlordCommand { get; set; }
        public RelayCommand LinkLandlordCommand { get; set; }
        public RelayCommand AddLandlordCommand { get; set; }
        public RelayCommand SaveLandlordsCommand { get; set; }
        public virtual ObservableCollection<Landlord> AllLandlords { get; set; }
        private AirBnBContext db { get; set; }

        ///Constructor
        public LandlordViewModel()
        {
            AddLandlordCommand = new RelayCommand(AddLandlord);
            LinkLandlordCommand = new RelayCommand(LinkLandlord);
            DeleteLandlordCommand = new RelayCommand(DeleteLandlord);
            SaveLandlordsCommand = new RelayCommand(SaveLandlords);

            db = new AirBnBContext();
            db.Landlords.Load();
            AllLandlords = db.Landlords.Local.ToObservableCollection();

        }

        private void DeleteLandlord()
        {
            db.Landlords.Remove(SelectedLandlord);
            AllLandlords.Remove(SelectedLandlord);
            db.SaveChanges();
        }

        private void LinkLandlord()
        {
            //link landlord to a property

        }

        private void AddLandlord()
        {
            Landlord newLandlord = new Landlord(
                "Firstname",
                "Lastname",
                "youremail@email.com",
                12345678,
                "Street",
                "City",
                "1234",
                "Country"
            );

            AllLandlords.Add(newLandlord);
            db.SaveChanges();
        }

        private void SaveLandlords()
        {
            db.SaveChanges();
        }
    }
}
