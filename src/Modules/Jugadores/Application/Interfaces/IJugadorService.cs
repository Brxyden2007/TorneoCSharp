using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Jugadores.Domain.Entities;

namespace TorneoCSharp.src.Modules.Jugadores.Application.Interfaces
{
    public interface IJugadorService
    {
        Task RegistrarJugadorAsync(string nombre, string paisEquipo, string apellido, int edad, string posicion, int dorsal, DateTime fechaNacimiento);
        Task ActualizarJugadorAsync(int id, string nuevoNombre, string nuevoApellido, int nuevaEdad, string nuevoPais, string nuevaPosicion, int nuevaDorsal);
        Task EliminarJugadorAsync(int id);
        Task<Jugador?> ObtenerJugadorPorIdAsync(int id);
    }
}