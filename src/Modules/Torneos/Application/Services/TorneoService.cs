using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Modules.Torneos.Application.Interfaces;
using LigaTorneo.src.Modules.Torneos.Domain.Entities;

namespace LigaTorneo.src.Modules.Torneos.Application.Services;

public class TorneoService
{
    private readonly ITorneoRepository _repo;

    public TorneoService(ITorneoRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Torneo>> ConsultarTorneosAsync()
    {
        return _repo.GetAllAsync();
    }

    public async Task RegistrarTorneoAsync(string nombre, DateTime fechainicio, DateTime fechafin)
    {
        var existentes = await _repo.GetAllAsync();
        if (existentes.Any(t => t.Nombre == nombre))
            throw new Exception("El torneo ya existe");
        var torneo = new Torneo
        {
            Nombre = nombre,
            FechaInicio = fechainicio,
            FechaFin = fechafin
        };

        _repo.Add(torneo);
        _repo.Update(torneo);
    }

    public async Task ActualizarTorneo(int id, string nuevoNombre, DateTime nuevaFechaInicio, DateTime nuevaFechaFin)
    {
        var torneo = await _repo.GetByIdAsync(id);

        if (torneo == null)
            throw new Exception($"Torneo con ID {id} no encontrado.");

        torneo.Nombre = nuevoNombre;
        torneo.FechaInicio = nuevaFechaInicio;
        torneo.FechaFin = nuevaFechaFin;

        _repo.Update(torneo);
        await _repo.SaveAsync();
    }

    public async Task EliminarTorneo(int id)
    {
        var torneo = await _repo.GetByIdAsync(id);
        if (torneo == null)
            throw new Exception($"Torneo con ID {id} no encontrado.");
        _repo.Remove(torneo);
        await _repo.SaveAsync();
    }

    public async Task<Torneo?> ObtenerTorneoPorIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }
}
