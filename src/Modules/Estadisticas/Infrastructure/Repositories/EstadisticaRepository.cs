using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using TorneoCSharp.src.Modules.Estadisticas.Application.Interfaces;
using TorneoCSharp.src.Modules.Estadisticas.Domain.Entities;

namespace TorneoCSharp.src.Modules.Estadisticas.Infrastructure.Repositories
{
    public class EstadisticaRepository : IEstadisticaRepository
    {
        private readonly AppDbContext _context;

        public EstadisticaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Estadistica?> GetByIdAsync(int id)
        {
            // Implementation to get an Equipo by Id
            return await _context.Estadisticas
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Estadistica>> GetAllEstadisticasAsync() =>
            // Implementation to get all Equipos
            await _context.Estadisticas.ToListAsync();

        public void Add(Estadistica estadistica) =>
        _context.Estadisticas.Add(estadistica);
        

        public void Remove(Estadistica estadistica) =>
        _context.Estadisticas.Remove(estadistica);
        

        public void Update(Estadistica estadistica) =>
        _context.Estadisticas.Update(estadistica);
        

        public async Task SaveAsync() =>
        await _context.SaveChangesAsync();
    }
}    