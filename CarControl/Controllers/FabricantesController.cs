using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarControl.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarControl.Controllers
{
    public class FabricantesController : Controller
    {
        public IActionResult Index()
        {
            List<Fabricante> list = new List<Fabricante>();
            list.Add(new Fabricante { Id = 1, Nome = "FIAT", Site = "www.fiat.com.br"});
            list.Add(new Fabricante { Id = 2, Nome = "Volvo", Site = "www.fiat.com.br"});

            return View(list);
        }
    }
}