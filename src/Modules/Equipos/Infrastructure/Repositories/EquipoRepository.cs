using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using TorneoCSharp.src.Modules.Equipos.Application.Interfaces;
using TorneoCSharp.src.Modules.Equipos.Domain.Entities;

namespace TorneoCSharp.src.Modules.Equipos.Infrastructure.Repositories
{
    public class EquipoRepository : IEquipoRepository
    {

        private readonly AppDbContext _context;

        public EquipoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Equipo?> GetByIdAsync(int id)
        {
            // Implementation to get an Equipo by Id
            return await _context.Equipos
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Equipo>> GetAllEquiposAsync() =>
            // Implementation to get all Equipos
            await _context.Equipos.ToListAsync();

        public void Add(Equipo entity) =>
        _context.Equipos.Add(entity);
        

        public void Remove(Equipo entity) =>
        _context.Equipos.Remove(entity);
        

        public void Update(Equipo entity) =>
        _context.Equipos.Update(entity);
        

        public async Task SaveAsync() =>
        await _context.SaveChangesAsync();
    }
}