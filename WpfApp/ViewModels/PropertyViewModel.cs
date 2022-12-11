using AirBnB.Models;
using GalaSoft.MvvmLight.Command;
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
        public ObservableCollection<Property> AllProperties { get; set; }


        ///Constructor
        public PropertyViewModel()
        {
            Property = new Property(
                "Alkmaarseweg 501",
                "Beverwijk",
                "The Netherlands",
                "1945DM",
                80.00,
                4,
                4,
                1,
                "Een mooi huisje in het centrum van Beverwijk",
                "Huis",
                "De Duijkertjes"
                );

            AllProperties = new ObservableCollection<Property>();
            AllProperties.Add(Property);
            AddPropertyCommand = new RelayCommand(AddProperty);
            DeletePropertyCommand = new RelayCommand(DeleteProperty);
        }


        private void DeleteProperty()
        {
            AllProperties.Remove(SelectedProperty);
        }

        private void AddProperty()
        {
            AllProperties.Add(new Property(
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
                ));

        }
    }
}
