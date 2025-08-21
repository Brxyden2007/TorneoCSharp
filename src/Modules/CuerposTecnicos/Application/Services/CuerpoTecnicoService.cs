using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using TorneoCSharp.src.Modules.CuerposTecnicos.Application.Interfaces;
using TorneoCSharp.src.Modules.CuerposTecnicos.Domain;

namespace TorneoCSharp.src.Modules.CuerposTecnicos.Application.Services
{
    public class CuerpoTecnicoService : ICuerpoTecnicoService
    {
        private readonly AppDbContext _context;

        public CuerpoTecnicoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Crear(CuerpoTecnico cuerpoTecnico)
        {
            _context.CuerposTecnicos.Add(cuerpoTecnico);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CuerpoTecnico>> Listar()
        {
            return await _context.CuerposTecnicos.ToListAsync();
        }

        public async Task<CuerpoTecnico?> BuscarPorId(int id)
        {
            return await _context.CuerposTecnicos.FindAsync(id);
        }

        public async Task Editar(CuerpoTecnico cuerpoTecnico)
        {
            _context.CuerposTecnicos.Update(cuerpoTecnico);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var entity = await _context.CuerposTecnicos.FindAsync(id);
            if (entity != null)
            {
                _context.CuerposTecnicos.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
