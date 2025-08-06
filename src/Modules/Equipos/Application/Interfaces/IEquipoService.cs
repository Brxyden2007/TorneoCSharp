using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Equipos.Domain.Entities;

namespace TorneoCSharp.src.Modules.Equipos.Application.Interfaces
{
    public interface IEquipoService
    {
        Task RegistrarEquipoAsync(string nombre, string paisEquipo, DateTime fechaCreacion);
        Task ActualizarEquipoAsync(int id, string nuevoNombre, DateTime fechaCreacion, string paisEquipo);
        Task EliminarEquipoAsync(int id);
        Task<Equipo?> ObtenerEquipoPorIdAsync(int id);
        Task<IEnumerable<Equipo>> ConsultarEquiposAsync();
    }
}