using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Jugadores.Application.Interfaces;
using TorneoCSharp.src.Modules.Jugadores.Domain.Entities;

namespace TorneoCSharp.src.Modules.Jugadores.Application.Services
{
    public class JugadorService
    {
        private readonly IJugadorRepository _repo;

        public JugadorService(IJugadorRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Jugador>> ConsultarJugadoresAsync()
    {
        return _repo.GetAllJugadoresAsync();
    }

    public async Task RegistrarJugadorAsync(string nombre, string apellido, int edad, string pais, DateTime fechaNacimiento)
    {
        var existentes = await _repo.GetAllJugadoresAsync();
        if (existentes.Any(j => j.Nombre == nombre))
            throw new Exception("El jugador ya existe");

        var jugador = new Jugador
        {
            Nombre = nombre,
            Apellido = apellido,
            Edad = edad,
            Pais = pais,
            FechaNacimiento = fechaNacimiento,
        };

        _repo.Add(jugador);
        await _repo.SaveAsync();
    }

    public async Task ActualizarJugadorAsync(int id, string nuevoNombre, string nuevoApellido, int nuevaEdad, string nuevoPais, DateTime nuevaFechaNacimiento)
    {
        var jugador = await _repo.GetByIdAsync(id);
        if (jugador == null)
            throw new Exception($"Jugador con ID {id} no encontrado.");

        jugador.Nombre = nuevoNombre;
        jugador.Apellido = nuevoApellido;
        jugador.Edad = nuevaEdad;
        jugador.Pais = nuevoPais;
        jugador.FechaNacimiento = nuevaFechaNacimiento;

        _repo.Update(jugador);
        await _repo.SaveAsync();
    }

    public async Task EliminarJugadorAsync(int id)
    {
        var jugador = await _repo.GetByIdAsync(id);
        if (jugador == null)
            throw new Exception($"Jugador con ID {id} no encontrado.");

        _repo.Remove(jugador);
        await _repo.SaveAsync();
    }
    
    public Task<Jugador?> ObtenerJugadorPorIdAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }

        internal async Task RegistrarJugadorAsync(string v1, string v2, string v3, DateTime dateTime, int v4)
        {
            await Task.CompletedTask;
        }
    }
}