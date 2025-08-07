using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Modules.Torneos.Domain.Entities;
using LigaTorneo.src.Shared.Context;
using TorneoCSharp.src.Modules.Equipos.Application.Services;
using TorneoCSharp.src.Modules.Equipos.Domain.Entities;
using TorneoCSharp.src.Modules.Equipos.Infrastructure.Repositories;

namespace TorneoCSharp.src.Modules.Equipos.UI;
    
public class MenuEquipos
{
private readonly AppDbContext _context;
readonly EquipoRepository repo = null!;
readonly EquipoService service = null!;
public MenuEquipos(AppDbContext context)
{
    _context = context;
    repo = new EquipoRepository(context);
    service = new EquipoService(repo);
}
    public async Task RenderMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Menú de Equipos");
            Console.WriteLine("1. Registrar Equipo");
            Console.WriteLine("2. Buscar Equipos");
            Console.WriteLine("3. Registrar Cuerpo Técnico");
            Console.WriteLine("4. Registrar Cuerpo Medico");
            Console.WriteLine("5. Inscripcion Torneo");
            Console.WriteLine("6. Notificacion de Transferencia");
            Console.WriteLine("7. Salir De Torneo");
            Console.WriteLine("8. Salir Main Menu");
            Console.Write("Seleccione una opción: ");
            var opeq = Console.ReadLine();
            switch (opeq)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Registrar Equipo seleccionado.");
                    Console.Write("Ingrese el nombre del equipo: ");
                    string nombreEquipo = Console.ReadLine()!;
                    Console.Write("Ingrese el país del equipo: ");
                    string paisEquipo = Console.ReadLine()!;
                    Console.Write("Fecha de Creacion (yyyy-MM-dd): ");
                    DateTime fechaCreacion = DateTime.Parse(Console.ReadLine()!);
                    Console.WriteLine($"Equipo '{nombreEquipo}' de {paisEquipo} creado el {fechaCreacion} registrado correctamente.");
                    await service.RegistrarEquipoAsync(nombreEquipo!, paisEquipo, fechaCreacion);
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("Ingrese el ID del equipo a buscar: ");
                    int idEquipo = int.Parse(Console.ReadLine()!);
                    Equipo? equipo = await service.ObtenerEquipoPorIdAsync(idEquipo);
                    if (equipo != null)
                    {
                        Console.WriteLine($"Equipo encontrado: {equipo.Nombre} ({equipo.Pais}) - Creado el {equipo.FechaCreacion}");
                    }
                    else
                    {
                        Console.WriteLine("Equipo no encontrado.");
                    }
                    break;
                case "3":
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    break;
                case "5":
                /*
                    Console.Clear();
                    Console.Write("Ingrese el ID del equipo a inscribir en el torneo: ");
                    int idEquipoTorneo = int.Parse(Console.ReadLine()!);
                    Console.Write("Ingrese el ID del torneo: ");
                    int idTorneo = int.Parse(Console.ReadLine()!);
                    Torneo? torneo = await _context.Torneos.FindAsync(idTorneo);
                    if (torneo != null)
                    {
                        Equipo? equipoTorneo = await service.ObtenerEquipoPorIdAsync(idEquipoTorneo);
                        if (equipoTorneo != null)
                        {
                            /// torneo.Equipos.Add(equipoTorneo);
                            _context.Torneos.Update(torneo);
                            await _context.SaveChangesAsync();
                            Console.WriteLine($"Equipo '{equipoTorneo.Nombre}' inscrito en el torneo '{torneo.Nombre}' correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Equipo no encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Torneo no encontrado.");
                    }
                    */
                    // "Funciona" (Solo es Visual, deduzco que tendre que acudir a una tabla intermedia para relacionar los equipos con los torneos)
                    break;
                case "6":
                /*
                    Console.Clear();
                    Console.WriteLine("Notificación de Transferencia seleccionada.");
                    Console.Write("Ingrese el ID del equipo: ");
                    int idEquipoTransferencia = int.Parse(Console.ReadLine()!);
                    Console.Write("Ingrese el ID del jugador: ");
                    int idJugador = int.Parse(Console.ReadLine()!);
                    Console.WriteLine($"Notificación de transferencia para el equipo con ID {idEquipoTransferencia} y jugador con ID {idJugador} registrada correctamente.");
                    */ break;
                    // "Funciona" (Solo es Visual, deduzco que tendre que acudir a una tabla intermedia para relacionar los equipos con los jugadores)
                case "7":
                /*
                    Console.Clear();
                    Console.Write("Ingrese el ID del equipo a salir del torneo: ");
                    int idEquipoSalir = int.Parse(Console.ReadLine()!);
                    await service.EliminarEquipoAsync(idEquipoSalir);
                    Console.WriteLine($"Equipo con ID {idEquipoSalir} eliminado del torneo correctamente.");
                    */ break; 
                    // "Funciona" (Solo es Visual, deduzco que tendre que acudir a una tabla intermedia para relacionar los equipos con los torneos lo mismo que el case 5)
                case "8":
                    Console.Clear();
                    Console.WriteLine("Saliendo al menú principal...");
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }     
}    