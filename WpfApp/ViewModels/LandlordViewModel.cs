using AirBnB.Model;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace AirBnB.ViewModels
{
    public class LandlordViewModel
    {
        public Landlord Landlord { get; set; }
        public Landlord SelectedLandlord { get; set; }
        public RelayCommand DeleteLandlordCommand { get; set; }
        public RelayCommand LinkLandlordCommand { get; set; }
        public RelayCommand AddLandlordCommand { get; set; }
        public ObservableCollection<Landlord> AllLandlords { get; set; }

        ///Constructor
        public LandlordViewModel()
        {
            AllLandlords = new ObservableCollection<Landlord>();
            AddLandlordCommand = new RelayCommand(AddLandlord);
            LinkLandlordCommand = new RelayCommand(LinkLandlord);
            DeleteLandlordCommand = new RelayCommand(DeleteLandlord);
        }

        private void DeleteLandlord()
        {
            AllLandlords.Remove(SelectedLandlord);
        }

        private void LinkLandlord()
        {
            //link landlord to a property

        }

        private void AddLandlord()
        {
            AllLandlords.Add(new Landlord(
                "Firstname",
                "Lastname",
                "youremail@email.com",
                12345678,
                "Street",
                "City",
                "1234",
                "Country"
                ));

        }
    }
}
