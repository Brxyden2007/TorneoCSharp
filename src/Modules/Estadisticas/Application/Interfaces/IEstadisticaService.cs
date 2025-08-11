using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Estadisticas.Domain.Entities;

namespace TorneoCSharp.src.Modules.Estadisticas.Application.Interfaces
{
    public interface IEstadisticaService
    {
        Task<IEnumerable<Estadistica>> GetAllEstadisticasAsync();
        Task<Estadistica?> GetEstadisticaByIdAsync(int id);
        Task AddEstadisticaAsync(Estadistica estadistica);
        Task UpdateEstadisticaAsync(Estadistica estadistica);
        Task DeleteEstadisticaAsync(int id);
    }
}