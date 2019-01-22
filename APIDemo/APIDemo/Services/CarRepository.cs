using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using APIDemo.Models;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Services
{
    public class CarRepository
    {
        private DbContextOptions<CarContext> options = new DbContextOptionsBuilder<CarContext>()
            .UseInMemoryDatabase(databaseName: "CarDatabase")
            .Options;
        
        private CarContext _context;

        public CarRepository()
        {
            _context = new CarContext(options);

        }

        public List<Car> GetCars()
        {
            List<Car> cars = _context.Cars.ToList();

            if (cars == null || cars.Count == 0)
            {
                cars = GetTestData();
                
            }
            UpdateCars(cars);
            return cars;
        }

        public void UpdateCars(List<Car> cars)
        {
            foreach (Car car in _context.Cars)
            {
                _context.Cars.Remove(car);
            }
            _context.SaveChanges();
            _context.Cars.AddRange(cars);
            _context.SaveChanges();
        }

        public List<Car> GetTestData()
        {
            return new List<Car>
            {
                new Car
                {
                    Id = "1",
                    _make = "Toyota",
                    _model = "Prado",
                    _year = "1995"
                },
                new Car()
                {
                    Id = "2",
                    _make = "Ford",
                    _model = "Ranger",
                    _year = "2019"
                }
            };
        }

        
    }
}
