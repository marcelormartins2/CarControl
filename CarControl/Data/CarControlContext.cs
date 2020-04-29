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
        public CarControlContext(DbContextOptions<CarControlContext> options)
            : base(options)
        {
        }

        public DbSet<AnoModelo> AnoModelo { get; set; }
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
        public DbSet<Parceiro> Parceiro { get; set; }
        public DbSet<Participacao> Participacao { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<Veiculo>  Veiculo { get; set; }

    }
}