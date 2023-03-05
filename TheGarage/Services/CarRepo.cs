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
        /// <summary>
        /// Gets a car from database by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A specefic car model</returns>
        public CarModel? GetCar(int id)
        {
            return _context.Cars.FirstOrDefault(c => c.CarId == id);
        }

        /// <summary>
        /// Gets a list of all cars from database.
        /// </summary>
        /// <returns>A list of car models.</returns> 
        public List<CarModel> GetCars()
        {
            return _context.Cars.ToList();
        }

        /// <summary>
        /// Adds a new car to the database.
        /// </summary>
        /// <param name="carToAdd">The car model to add to database.</param>
        public void AddCar(CarModel carToAdd)
        {
            _context.Cars.Add(carToAdd);
        }

        /// <summary>
        /// Remove the specified car by its Id.
        /// </summary>
        /// <param name="id">The Id of the car to remove.</param>
        public void RemoveTheCar(int id)
        {
            var carToRemove = _context.Cars.FirstOrDefault(c => c.CarId == id);
            if (carToRemove != null)
            {
                _context.Cars.Remove(carToRemove);
            }
        }


    }
}
