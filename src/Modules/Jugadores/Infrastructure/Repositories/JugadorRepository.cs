using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using TorneoCSharp.src.Modules.Jugadores.Application.Interfaces;
using TorneoCSharp.src.Modules.Jugadores.Domain.Entities;

namespace TorneoCSharp.src.Modules.Jugadores.Infrastructure.Repositories
{
    public class JugadorRepository : IJugadorRepository
    {
        private readonly AppDbContext _context;

        public JugadorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Jugador?> GetByIdAsync(int id)
        {
            // Implementation to get an Equipo by Id
            return await _context.Jugadores
                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<IEnumerable<Jugador>> GetAllJugadoresAsync() =>
            // Implementation to get all Equipos
            await _context.Jugadores.ToListAsync();

        

        public void Add(Jugador jugador) =>
        _context.Jugadores.Add(jugador);
        

        public void Remove(Jugador jugador) =>
        _context.Jugadores.Remove(jugador);
        

        public void Update(Jugador jugador) =>
        _context.Jugadores.Update(jugador);
        

        public async Task SaveAsync() =>
        await _context.SaveChangesAsync();
    }
}
