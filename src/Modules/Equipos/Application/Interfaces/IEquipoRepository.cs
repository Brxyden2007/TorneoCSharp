using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Equipos.Domain.Entities;

namespace TorneoCSharp.src.Modules.Equipos.Application.Interfaces
{
    public interface IEquipoRepository
    {
        Task<Equipo?> GetByIdAsync(int id);
        Task<IEnumerable<Equipo>> GetAllEquiposAsync();
        void Add(Equipo entity);
        void Remove(Equipo entity);
        void Update(Equipo entity);
        Task SaveAsync();
    }
}