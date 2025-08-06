using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Equipos.Application.Interfaces;
using TorneoCSharp.src.Modules.Equipos.Domain.Entities;

namespace TorneoCSharp.src.Modules.Equipos.Application.Services;

public class EquipoService
{
    private readonly IEquipoRepository _repo;

    public EquipoService(IEquipoRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Equipo>> ConsultarEquiposAsync()
    {
        return _repo.GetAllEquiposAsync();
    }

    public async Task RegistrarEquipoAsync(string nombre, string paisEquipo, DateTime fechaCreacion)
    {
        var existentes = await _repo.GetAllEquiposAsync();
        if (existentes.Any(e => e.Nombre == nombre))
            throw new Exception("El equipo ya existe");

        var equipo = new Equipo
        {
            Nombre = nombre,
            Pais = paisEquipo,
            FechaCreacion = fechaCreacion
        };

        _repo.Add(equipo);
        await _repo.SaveAsync();
    }

    public async Task ActualizarEquipoAsync(int id, string nuevoNombre, DateTime fechaCreacion, string paisEquipo)
    {
        var equipo = await _repo.GetByIdAsync(id);
        if (equipo == null)
            throw new Exception($"Equipo con ID {id} no encontrado.");

        equipo.Nombre = nuevoNombre;
        equipo.FechaCreacion = fechaCreacion;
        equipo.Pais = paisEquipo;

        _repo.Update(equipo);
        await _repo.SaveAsync();
    }

    public async Task RegistrarCuerpoTecnicoAsync(string DirectorTecnico, string AsistenteTecnico, string PreparadorFisico, string EntrenadorPortero, int idEquipo)
    {
        var existentes = await _repo.GetByIdAsync(idEquipo);
        if (existentes == null)
            throw new Exception("Equipo no encontrado");
        await Task.CompletedTask;
    }

    public async Task EliminarEquipoAsync(int id)
    {
        var equipo = await _repo.GetByIdAsync(id);
        if (equipo == null)
            throw new Exception($"Equipo con ID {id} no encontrado.");

        _repo.Remove(equipo);
        await _repo.SaveAsync();
    }
    
    public Task<Equipo?> ObtenerEquipoPorIdAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }
}
