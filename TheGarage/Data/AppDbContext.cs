using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Models;

namespace TheGarage.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TheGarage;Trusted_Connection=True;");
        }

        // The Cars table in database
        public virtual DbSet<CarModel> Cars { get; set; }

        // Prefilling the databse by seeding data 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>().HasData(new CarModel()
            {
                CarId= 1,
                Mark= "Lamborghini",
                Model = "Urus Performante",
                IsElectric = false,
                NumberOfSeats= 5,  
            }, new CarModel()
            {
                CarId = 2,
                Mark = "Volvo",
                Model = "XC 40",
                IsElectric = false,
                NumberOfSeats = 5,
            }, new CarModel()
            {
                CarId = 3,
                Mark = "Audi",
                Model = "S5",
                IsElectric = false,
                NumberOfSeats = 4,
            }, new CarModel()
            {
                CarId = 4,
                Mark = "Entap",
                Model = "Mada 9",
                IsElectric = false,
                NumberOfSeats = 2,
            });
        }
    }
    
    
}
