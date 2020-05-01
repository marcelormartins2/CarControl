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
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Fabricantes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nome,Site")] Fabricante fabricante)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(fabricante);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(fabricante);
        //}

        //// GET: Fabricantes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var fabricante = await _context.Fabricante.FindAsync(id);
        //    if (fabricante == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(fabricante);
        //}

        //// POST: Fabricantes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Site")] Fabricante fabricante)
        //{
        //    if (id != fabricante.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(fabricante);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FabricanteExists(fabricante.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(fabricante);
        //}

        //// GET: Fabricantes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var fabricante = await _context.Fabricante
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (fabricante == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(fabricante);
        //}

        //// POST: Fabricantes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var fabricante = await _context.Fabricante.FindAsync(id);
        //    _context.Fabricante.Remove(fabricante);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool FabricanteExists(int id)
        //{
        //    return _context.Fabricante.Any(e => e.Id == id);
        //}
    }
}
