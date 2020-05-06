using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarControl.Models;
using CarControl.Data;
using Microsoft.EntityFrameworkCore;
using CarControl.Services.Exceptions;

namespace CarControl.Services
{
    public class FabricanteService
    {
        public readonly CarControlContext _context;

        public FabricanteService(CarControlContext context)
        {
            _context = context;
        }

        public async Task<List<Fabricante>> FindAllAsync()
        {
            return await _context.Fabricante.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Fabricante> FindAsync(int id)
        {
            var fabricante = _context.Fabricante; 
                var result = from obj in _context.ModeloCar select obj;
            result = result.Where(x => x.FabricanteId==id);
            if (!result.Any())
            {
                return await fabricante.FirstOrDefaultAsync(x=>x.Id==id);
            }
            return await fabricante.Include(x => x.ModeloCar).FirstOrDefaultAsync(z=>z.Id==id);
        }

        public async Task AddAsync(Fabricante fabricante)
        {
            _context.Add(fabricante);
            await _context.SaveChangesAsync();

        }

        public async Task Update(Fabricante fabricante)
        {
            _context.Update(fabricante);
            await _context.SaveChangesAsync();
            
        }

        internal bool Any(int id)
        {
            return _context.Fabricante.Any(e => e.Id == id);
        }

        internal async Task DeleteAsync(int id)
        {
            try
            {
                var fabricante = await _context.Fabricante.FindAsync(id);
                _context.Fabricante.Remove(fabricante);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Can't delete seller because he/she has sales");
            }
            
            
        }
    }
 }
