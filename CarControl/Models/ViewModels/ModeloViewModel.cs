using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarControl.Models.ViewModels
{
    public class ModeloViewModel
    {
        public Fabricante Fabricante { get; set; }
        public ICollection<Fabricante> ListFabricante { get; set; } = new List<Fabricante>();
        public ICollection<Modelo> Modelos { get; set; }
    }
}
