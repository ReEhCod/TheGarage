using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using TheGarage.Data;
using TheGarage.Models;

namespace TheGarage.Services
{
    public class CarRepo
    {
        // Making a readonly instance of AppDbContext
        private readonly AppDbContext _context;
        public CarRepo(AppDbContext context)
        {
            _context = context;
        }

        // Get one car by its id
        public CarModel? GetCar(int id)
        {
            return _context.Cars.FirstOrDefault(c => c.CarId == id);
        }
        public List<CarModel> GetCars()
        {
            return _context.Cars.ToList();
        }

        // Get all cars 
        public async Task<List<CarModel>> GetCarsAsync()
        {
            return await _context.Cars.ToList();
        }


    }
}
