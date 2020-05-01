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

        public async Task<List<ModeloCar>> FindAsync(int fabricanteid)
        {


            var objModeloCar = from obj in _context.ModeloCar select obj;
            objModeloCar = objModeloCar.Where(x => x.FabricanteId == fabricanteid);
            
            return await objModeloCar
                .Include(x => x.Fabricante)
                .OrderByDescending(x => x.Nome)
                .ToListAsync();
        }
    }
}