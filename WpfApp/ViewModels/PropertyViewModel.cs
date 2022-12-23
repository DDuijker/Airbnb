using AirBnB.Models;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace AirBnB.ViewModels

{
    public class PropertyViewModel
    {
        public Property Property { get; set; }
        public Property SelectedProperty { get; set; }
        public RelayCommand DeletePropertyCommand { get; set; }
        public RelayCommand LinkPropertyCommand { get; set; }
        public RelayCommand AddPropertyCommand { get; set; }
        public RelayCommand SavePropertyCommand { get; set; }
        public virtual ObservableCollection<Property> AllProperties { get; set; }
        private AirBnBContext db { get; set; }


        ///Constructor
        public PropertyViewModel()
        {
            AddPropertyCommand = new RelayCommand(AddProperty);
            DeletePropertyCommand = new RelayCommand(DeleteProperty);
            SavePropertyCommand = new RelayCommand(SaveProperties);
            db = new AirBnBContext();

            db.Properties.Load();
            AllProperties = db.Properties.Local.ToObservableCollection();
        }


        private ObservableCollection<Property> GetAllProperties()
        {
            return AllProperties;
        }

        private void DeleteProperty()
        {
            db.Properties.Remove(SelectedProperty);
            AllProperties.Remove(SelectedProperty);
            db.SaveChanges();
        }

        private void AddProperty()
        {
            Property newProperty = new Property(
                "----",
                "----",
                "----",
                "----",
                0.00,
                0,
                0,
                0,
                "----",
                "----",
                "----"
            );

            AllProperties.Add(newProperty);
            db.SaveChanges();
        }

        private void SaveProperties()
        {
            db.SaveChanges();
        }
    }
}
