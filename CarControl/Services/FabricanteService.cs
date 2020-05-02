using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarControl.Models;
using CarControl.Data;
using Microsoft.EntityFrameworkCore;

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
    }
 }
