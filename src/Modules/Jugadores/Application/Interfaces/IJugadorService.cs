using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Jugadores.Domain.Entities;

namespace TorneoCSharp.src.Modules.Jugadores.Application.Interfaces
{
    public interface IJugadorService
    {
        Task RegistrarJugadorAsync(string nombre, string paisEquipo, DateTime fechaCreacion);
        Task ActualizarJugadorAsync(int id, string nuevoNombre, DateTime fechaCreacion, string paisEquipo);
        Task EliminarJugadorAsync(int id);
        Task<Jugador?> ObtenerJugadorPorIdAsync(int id);
    }
}