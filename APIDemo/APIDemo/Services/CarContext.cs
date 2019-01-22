using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Services
{
    public class CarContext : DbContext
    {

        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
