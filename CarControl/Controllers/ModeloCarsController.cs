using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarControl.Data;
using CarControl.Models;
using CarControl.Services;

namespace CarControl.Controllers
{
    public class ModeloCarsController : Controller
    {
        private readonly ModeloCarService _modeloCarService;
        private readonly CarControlContext _context;
        private readonly FabricanteService _fabricanteService;

        public ModeloCarsController(ModeloCarService modeloCarService, CarControlContext context, FabricanteService fabricanteService)
        {
            _modeloCarService = modeloCarService;
            _context = context;
            _fabricanteService = fabricanteService;
        }



        // GET: ModeloCars
        public async Task<IActionResult> Index()
        {
           return View(await _modeloCarService.FindAllAsync());
        }

        // GET: ModeloCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloCar = await _modeloCarService.FindAsync(id.Value);
            if (modeloCar == null)
            {
                return NotFound();
            }

            return View(modeloCar);
        }

        // GET: ModeloCars/Create
        public async Task<IActionResult> Create()
        {
            ViewData["FabricanteId"] = new SelectList(await _fabricanteService.FindAllAsync(), "Id", "Nome");
            return View();
        }

        // POST: ModeloCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FabricanteId,Nome")] ModeloCar modeloCar)
        {
            if (ModelState.IsValid)
            {
                await _modeloCarService.AddAsync(modeloCar);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FabricanteId"] = new SelectList(await _fabricanteService.FindAllAsync(), "Id", "Nome", modeloCar.FabricanteId);
            return View(modeloCar);
        }

        // GET: ModeloCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloCar = await _modeloCarService.FindAsync(id.Value);
            if (modeloCar == null)
            {
                return NotFound();
            }
            ViewData["FabricanteId"] = new SelectList(await _fabricanteService.FindAllAsync(), "Id", "Nome", modeloCar.FabricanteId);
            return View(modeloCar);
        }

        // POST: ModeloCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FabricanteId,Nome")] ModeloCar modeloCar)
        {
            if (id != modeloCar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _modeloCarService.UpdateAsync(modeloCar);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloCarExists(modeloCar.Id))
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
            ViewData["FabricanteId"] = new SelectList(await _fabricanteService.FindAllAsync(), "Id", "Nome", modeloCar.FabricanteId);
            return View(modeloCar);
        }

        // GET: ModeloCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloCar = await _modeloCarService.FindAsync(id.Value);
            if (modeloCar == null)
            {
                return NotFound();
            }

            return View(modeloCar);
        }

        // POST: ModeloCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _modeloCarService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloCarExists(int id)
        {
            return _context.ModeloCar.Any(e => e.Id == id);
        }
    }
}
