using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarControl.Data;
using CarControl.Models;
using Microsoft.EntityFrameworkCore;

namespace CarControl.Services
{
    public class ModeloCarService
    {
        public readonly CarControlContext _context;

        public ModeloCarService(CarControlContext context)
        {
            _context = context;
        }

        public async Task<ModeloCar> FindAsync(int id)
        {

            return await _context.ModeloCar
                            .Include(m => m.Fabricante)
                            .FirstOrDefaultAsync(m => m.Id == id);
            //var objModeloCar = from obj in _context.ModeloCar select obj;
            //objModeloCar = objModeloCar.Where(x => x.FabricanteId == fabricanteid);
            
            //return await objModeloCar
            //    .Include(x => x.Fabricante)
            //    .OrderByDescending(x => x.Nome)
            //    .ToListAsync();
        }

        internal async Task<List<ModeloCar>> FindAllAsync()
        {
            var modeloCar = _context.ModeloCar.Include(m => m.Fabricante);
            return await modeloCar.OrderBy(x=>x.FabricanteId).ToListAsync();
        }

        internal async Task AddAsync(ModeloCar modeloCar)
        {
            _context.Add(modeloCar);
            await _context.SaveChangesAsync();
        }

        internal async Task UpdateAsync(ModeloCar modeloCar)
        {
            _context.Update(modeloCar);
            await _context.SaveChangesAsync();
        }

        internal async Task DeleteAsync(int id)
        {
            var modeloCar = await _context.ModeloCar.FindAsync(id);
            _context.ModeloCar.Remove(modeloCar);
            await _context.SaveChangesAsync();
        }
    }
}