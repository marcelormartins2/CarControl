﻿using System;
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
            var fabricante = await _context.Fabricante
                .Include(m => m.ModeloCar.Where(x=>x.FabricanteId == id)
                .FirstOrDefaultAsync(m => m.Id == id);

            return fabricante;
        }
    }
 }
