using AirBnB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnB
{
    internal class AirBnBContext : DbContext
    {
        public DbSet<Landlord> Landlords { get; set; }
        public DbSet<Property> Properties { get; set; }


        public AirBnBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
            // optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=StudentenDatabase;Integrated Security=SSPI;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
