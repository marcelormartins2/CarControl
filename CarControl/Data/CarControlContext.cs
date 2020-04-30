using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarControl.Models;

namespace CarControl.Data
{
    public class CarControlContext : DbContext
    {
        public CarControlContext (DbContextOptions<CarControlContext> options)
            : base(options)
        {
        }

        public DbSet<CarControl.Models.Fabricante> Fabricante { get; set; }
    }
}
