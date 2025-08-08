using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Modules.Torneos.Application;
using LigaTorneo.src.Modules.Torneos.Domain.Entities;
using LigaTorneo.src.Modules.Torneos.Application.Services;
using LigaTorneo.src.Shared.Context;
using LigaTorneo.src.Modules.Torneos.Infrastructure.Repositories;
using TorneoCSharp.src.Modules.Equipos.Domain.Entities;
namespace LigaTorneo.src.Modules.Torneos.UI;

public class MenuTorneos
{
    private readonly AppDbContext _context;
    readonly TorneoRepository repo = null!;
    readonly TorneoService service = null!;
    public MenuTorneos(AppDbContext context)
    {
        _context = context;
        repo = new TorneoRepository(context);
        service = new TorneoService(repo);
    }
    public async Task RenderMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n --- Menu Torneo ---");
            Console.WriteLine("1. Añadir Torneo");
            Console.WriteLine("2. Buscar Torneo");
            Console.WriteLine("3. Eliminar Torneo");
            Console.WriteLine("4. Actualizar Torneo");
            Console.WriteLine("5. Mostrar Equipos en Torneo (Pendiente)");
            Console.WriteLine("6. Regresar Main Menu");
            Console.Write("Opcion: ");
            int opt = int.Parse(Console.ReadLine()!);

            switch (opt)
            {
                case 1: // Done
                    Console.Clear();
                    Console.Write("Nombre de Torneo: ");
                    string? nombre = Console.ReadLine();
                    Console.Write("Fecha de Inicio (yyyy-MM-dd): ");
                    DateTime fechaInicio = DateTime.Parse(Console.ReadLine()!);
                    Console.Write("Fecha de Fin (yyyy-MM-dd): ");
                    DateTime fechaFin = DateTime.Parse(Console.ReadLine()!);
                    await service.RegistrarTorneoAsync(nombre!, fechaInicio, fechaFin);
                    break;

                case 2:
                    Console.Clear();
                    Console.Write("Ingrese el ID del torneo a buscar: ");
                    int id = int.Parse(Console.ReadLine()!);
                    Torneo? tournament = await service.ObtenerTorneoPorIdAsync(id);
                    if (tournament != null)
                        Console.WriteLine($"Nombre: {tournament.Nombre}\nInicio: {tournament.FechaInicio:yyyy-MM-dd}\nFin: {tournament.FechaFin:yyyy-MM-dd}");
                    else
                        Console.WriteLine("Torneo No Encontrado");
                    break;

                case 3:
                    Console.Clear();
                    Console.Write("ID del Torneo a Eliminar: ");
                    int idDelTor = int.Parse(Console.ReadLine()!);
                    await service.EliminarTorneo(idDelTor);
                    Console.WriteLine("Torneo Eliminado.");
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("ID de Torneo a Actualizar: ");
                    int idUpTor = int.Parse(Console.ReadLine()!);
                    Console.Write("Nuevo Nombre: ");
                    string? nuevoNombre = Console.ReadLine();
                    Console.Write("Nueva Fecha de Inicio (yyyy-MM-dd): ");
                    DateTime nuevaFechaInicio = DateTime.Parse(Console.ReadLine()!);
                    Console.Write("Nueva Fecha de Fin (yyyy-MM-dd): ");
                    DateTime nuevaFechaFin = DateTime.Parse(Console.ReadLine()!);
                    await service.ActualizarTorneo(idUpTor, nuevoNombre!, nuevaFechaInicio, nuevaFechaFin);
                    break;
                case 5:
                    Console.Clear();
                     /*
                    Console.Write("ID del Torneo para mostrar Equipos: ");
                    int idTorneo = int.Parse(Console.ReadLine()!);
                    var torneo = await service.ObtenerTorneoPorIdAsync(idTorneo);
                    if (torneo != null)
                    {
                        Console.WriteLine($"Equipos en el Torneo {torneo.Nombre}:");
                        foreach (var equipo in torneo.Equipos)
                        {
                            Console.WriteLine($"- {equipo.Nombre} (Pais: {equipo.Pais})");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Torneo No Encontrado");
                    }
                    Console.WriteLine("Funcionalidad pendiente de implementación.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();*/
                    break;    
                case 6:
                    salir = true;
                    break;
            } 
            
        }
    }
}
