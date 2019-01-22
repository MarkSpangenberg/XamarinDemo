using System;
using System.Collections.Generic;
using APIDemo.Models;
using APIDemo.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            CarRepository carRepository = new CarRepository();

            List<Car> car = carRepository.GetCars();

            return car;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post(List<Car> cars)
        {
            CarRepository carRepository = new CarRepository();
            carRepository.UpdateCars(cars);
            return Ok();
        }
    }
}
