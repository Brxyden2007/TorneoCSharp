using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Jugadores.Domain.Entities;

namespace TorneoCSharp.src.Modules.Jugadores.Application.Interfaces
{
    public interface IJugadorRepository
    {
        Task<Jugador?> GetByIdAsync(int id);
        Task<IEnumerable<Jugador>> GetAllJugadoresAsync();
        void Add(Jugador entity);
        void Remove(Jugador entity);
        void Update(Jugador entity);
        Task SaveAsync();
    }
}