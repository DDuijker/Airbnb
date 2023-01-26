using MVC.Data;
using MVC.Models;
using System.Linq;

namespace MVC.ViewModels
{
    public class OverviewView
    {
        public List<Property> Properties { get; set; }
        public string Mode { get; set; }
        private AirBnbContext _db { get; set; }
        public int ReservationCount { get; set; }
        public int SortedPropertiesCount { get; set; }
        public List<string> UniqueCities { get; set; }
        public List<string> UniqueCountries { get; set; }
        public List<int> Unique { get; set; }
        public List<int> UniqueBathrooms { get; set; }
        public List<int> UniqueBeds { get; set; }
        public List<int> UniqueRooms { get; set; }
        public double CheapestProperty { get; set; }
        public double MostExpensiveProperty { get; set; }
        public List<string> UniqueTypes { get; set; }
        public int PropertyCount { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Property> SortedProperties { get; set; }
        public void Load(AirBnbContext db, int? id= null)
        {
            _db = db;
            ReservationCount = db.Reservations.Count();
            /*Customers = db.Customers.Local.ToList();*/
            Reservations = db.Reservations.ToList();
            PropertyCount = db.Properties.Count();
            /*Customers = db.Customers.Local.ToList();*/
            Properties = db.Properties.ToList();

            //unique lists
            UniqueCities = db.Properties.Select(c => c.City).Distinct().ToList();
  
            UniqueCountries = db.Properties.Select(c => c.Country).Distinct().ToList();
            
            UniqueTypes = db.Properties.Select(c => c.Type).Distinct().ToList();

            UniqueRooms = db.Properties.Select(c => c.NumberOfRooms).Distinct().ToList();

            UniqueBeds = db.Properties.Select(c => c.NumberOfBeds).Distinct().ToList();

            UniqueBathrooms = db.Properties.Select(c => c.NumberOfBathrooms).Distinct().ToList();

            CheapestProperty = db.Properties.Select(c => c.Price).OrderBy(c => c).Distinct().ToList().First();

            MostExpensiveProperty = db.Properties.Select(c => c.Price).OrderBy(c => c).Distinct().ToList().Last();

        }

        public void Sort( string? metric, string? attribute = null)
        {
            if(metric != null)
            {

            string[] metricArray = metric.Split('_');
            int itteration = 0;
            string searchMetric = "";
            foreach (string str in metricArray)
            {
                if(itteration == 0)
                {
                    searchMetric += str;
                } else
                {
                    searchMetric += " ";
                    searchMetric += str;

                }
                itteration++;
            }
            metric = searchMetric;
            }

            switch (attribute)
            {
                case "Search":
                    List<Property> PropertiesList = _db.Properties.ToList();
                    Mode = "search";
                    foreach (var property in PropertiesList)
                    {
                       /* bool test = property.Title.ToLower().Contains("Neat ".ToLower()) == true;
                        Console.WriteLine(test);*/
                        if (property.Address.ToLower().Contains(metric.ToLower()) || 
                            property.City.ToLower().Contains(metric.ToLower()) || 
                            property.Title.ToLower().Contains(metric.ToLower()) || 
                            property.Type.ToLower().Contains(metric.ToLower()) || 
                            property.Zip.ToLower().Contains(metric.ToLower()) ||
                            property.Description.ToLower().Contains(metric.ToLower()) ||
                            Convert.ToString(property.Price).Contains(metric) || 
                            property.City.ToLower().Contains(metric.ToLower()))
                        {
                        SortedProperties.Add(property);
                            
                        }
                     
                    }
                    break;
                case "Address":
                    SortedProperties = _db.Properties.Where(r => r.Address.Contains(metric)).ToList();
                    Mode = "search";
                    break;

                case "City":
                    SortedProperties = _db.Properties.Where(r => r.City.Contains(metric)).ToList();
                    Mode = "search";
                    break;
                case "Rooms":
                    SortedProperties = _db.Properties.Where(r => r.NumberOfRooms == Convert.ToInt32(metric)).ToList();
                    Mode = "search";
                    break;
                case "Beds":
                    SortedProperties = _db.Properties.Where(r => r.NumberOfBeds == Convert.ToInt32(metric)).ToList();
                    Mode = "search";
                    break;
                case "Bathrooms":
                    SortedProperties = _db.Properties.Where(r => r.NumberOfBathrooms == Convert.ToInt32(metric)).ToList();
                    Mode = "search";
                    break;
                case "Zip":
                    SortedProperties = _db.Properties.Where(r => r.Zip == metric).ToList();
                    Mode = "search";
                    break;
                case "Price":
                    SortedProperties = _db.Properties.Where(r => r.Price <= Convert.ToDouble(metric)).OrderBy(c => c.Price).ToList();
                    Mode = "search";
                    break;
                case "Type":
                    SortedProperties = _db.Properties.Where(r => r.Type == metric).ToList();
                    Mode = "search";
                    break;
                case "Country":
                    SortedProperties = _db.Properties.Where(r => r.Country == metric).ToList();
                    Mode = "search";
                    break;
                default:
                    Mode = "overview";
                    break;
            }
           Console.Write(Mode);
       
        }

        public OverviewView()
        {
            Reservations = new List<Reservation>();
            SortedProperties = new List<Property>();
            Properties = new List<Property>();

        }
    }
}
