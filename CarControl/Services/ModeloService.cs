using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarControl.Data;
using CarControl.Models;
using Microsoft.EntityFrameworkCore;

namespace CarControl.Services
{
    public class ModeloService
    {
        public readonly CarControlContext _context;

        public ModeloService(CarControlContext context)
        {
            _context = context;
        }

        public async Task<List<Modelo>> FindAllAsync(int fabricanteid)
        {
            var result = from obj in _context.Modelo select obj;
            result = result.Where(x => x.FabricanteId == fabricanteid);
            
            return await result
                .Include(x => x.Fabricante)
                .OrderByDescending(x => x.Nome)
                .ToListAsync();
        }
    }
}