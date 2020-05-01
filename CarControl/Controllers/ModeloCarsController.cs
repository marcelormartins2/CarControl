using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarControl.Data;
using CarControl.Models;

namespace CarControl.Controllers
{
    public class ModeloCarsController : Controller
    {
        private readonly CarControlContext _context;

        public ModeloCarsController(CarControlContext context)
        {
            _context = context;
        }

        // GET: ModeloCars
        public async Task<IActionResult> Index()
        {
            var carControlContext = _context.ModeloCar.Include(m => m.Fabricante);
            return View(await carControlContext.ToListAsync());
        }

        // GET: ModeloCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloCar = await _context.ModeloCar
                .Include(m => m.Fabricante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modeloCar == null)
            {
                return NotFound();
            }

            return View(modeloCar);
        }

        // GET: ModeloCars/Create
        public IActionResult Create()
        {
            ViewData["FabricanteId"] = new SelectList(_context.Fabricante, "Id", "Id");
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
                _context.Add(modeloCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FabricanteId"] = new SelectList(_context.Fabricante, "Id", "Id", modeloCar.FabricanteId);
            return View(modeloCar);
        }

        // GET: ModeloCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloCar = await _context.ModeloCar.FindAsync(id);
            if (modeloCar == null)
            {
                return NotFound();
            }
            ViewData["FabricanteId"] = new SelectList(_context.Fabricante, "Id", "Id", modeloCar.FabricanteId);
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
                    _context.Update(modeloCar);
                    await _context.SaveChangesAsync();
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
            ViewData["FabricanteId"] = new SelectList(_context.Fabricante, "Id", "Id", modeloCar.FabricanteId);
            return View(modeloCar);
        }

        // GET: ModeloCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloCar = await _context.ModeloCar
                .Include(m => m.Fabricante)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var modeloCar = await _context.ModeloCar.FindAsync(id);
            _context.ModeloCar.Remove(modeloCar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloCarExists(int id)
        {
            return _context.ModeloCar.Any(e => e.Id == id);
        }
    }
}
