using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

                    // Lógica para inscripción torneo
                    break;
                case "5":

                    // Lógica para notificación de transferencia
                    break;
                case "6":

                    // Lógica para salir de torneo
                    break;
                case "7":

                    // Lógica para salir al menú principal
                    break;
                case "8":
                    Console.Clear();
                    Console.WriteLine("Saliendo al menú principal...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }     
}    