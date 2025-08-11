using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Estadisticas.Domain.Entities;

namespace TorneoCSharp.src.Modules.Estadisticas.Application.Interfaces
{
    public interface IEstadisticaRepository
    {
        Task<Estadistica?> GetByIdAsync(int id);
        Task<IEnumerable<Estadistica>> GetAllEstadisticasAsync();
        void Add(Estadistica estadistica);
        void Remove(Estadistica estadistica);
        void Update(Estadistica estadistica);
        Task SaveAsync();
        
    }
}