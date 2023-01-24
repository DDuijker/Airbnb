using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1
{
    public class AirBnbContext : DbContext
    {
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public string DbPath { get; }


        public AirBnbContext()
        {
           var folder = Environment.SpecialFolder.LocalApplicationData;
           var path = Environment.GetFolderPath(folder);
           DbPath = System.IO.Path.Join(path, "database.db");

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          // optionsBuilder.UseSqlite($"Data Source=database.db");

            optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=StudentWeb.Data;Trusted_Connection=True;MultipleActiveResultSets=true" ?? throw new InvalidOperationException("Connection string 'StudentContext' not found."));
            // optionsBuilder.UseMySQL("server=localhost;user=root;database=airbnb;password=12345678;port=3306");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
