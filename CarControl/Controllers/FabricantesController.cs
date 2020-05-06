using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarControl.Data;
using CarControl.Models;
using CarControl.Models.ViewModels;
using CarControl.Services;
using CarControl.Services.Exceptions;
using System.Diagnostics;

namespace CarControl.Controllers
{
    public class FabricantesController : Controller
    {
        private readonly FabricanteService _fabricanteService;
        private readonly ModeloCarService _modeloCarService;

        public FabricantesController(FabricanteService fabricanteService, ModeloCarService modeloService)
        {
            _fabricanteService = fabricanteService;
            _modeloCarService = modeloService;
        }



        // GET: Fabricantes
        public async Task<IActionResult> Index()
        {
            var list = await _fabricanteService.FindAllAsync();
            return View(list);
        }

        // GET: Fabricantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fabricante = await _fabricanteService.FindAsync(id.Value);
            if (fabricante == null)
            {
                return NotFound();
            }
            return View(fabricante);
        }

        //// GET: Fabricantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fabricantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Site")] Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                await _fabricanteService.AddAsync(fabricante);
                return RedirectToAction(nameof(Index));
            }
            return View(fabricante);
        }

        // GET: Fabricantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fabricante = await _fabricanteService.FindAsync(id.Value);
            if (fabricante == null)
            {
                return NotFound();
            }
            return View(fabricante);
        }

        // POST: Fabricantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Site")] Fabricante fabricante)
        {
            if (id != fabricante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _fabricanteService.Update(fabricante);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FabricanteExists(fabricante.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fabricante);
        }

        // GET: Fabricantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fabricante = await _fabricanteService.FindAsync(id.Value);
            if (fabricante == null)
            {
                return NotFound();
            }

            return View(fabricante);
        }

        // POST: Fabricantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _fabricanteService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        private bool FabricanteExists(int id)
        {
            return _fabricanteService.Any(id);
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
