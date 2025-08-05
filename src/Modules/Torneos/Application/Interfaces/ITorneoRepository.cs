using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Modules.Torneos.Domain.Entities;

namespace LigaTorneo.src.Modules.Torneos.Application.Interfaces
{
    public interface ITorneoRepository
    {
        Task<Torneo?> GetByIdAsync(int id);
        Task<IEnumerable<Torneo?>> GetAllAsync();
        void Add(Torneo entity);
        void Remove(Torneo entity);
        void Update(Torneo entity);
        Task SaveAsync();
    }
}