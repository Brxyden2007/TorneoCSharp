using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Modules.Torneos.Domain.Entities;

namespace LigaTorneo.src.Modules.Torneos.Application.Interfaces;

public interface ITorneoService
{
    Task RegistrarTorneoAsync(string nombre);
    Task ActualizarTorneo(int id, string nuevoNombre);
    Task EliminarTorneo(int id);
    Task<Torneo?> ObtenerTorneoPorIdAsync(int id);
    Task<IEnumerable<Torneo>> ConsultarTorneosAsync();    
}
