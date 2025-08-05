using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Modules.Torneos.Application;
using LigaTorneo.src.Modules.Torneos.Domain.Entities;
using LigaTorneo.src.Modules.Torneos.Application.Services;
using LigaTorneo.src.Shared.Context;
using LigaTorneo.src.Modules.Torneos.Infrastructure.Repositories;
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
            Console.WriteLine("5. Regresar Main Menu");
            Console.Write("Opcion: ");
            int opt = int.Parse(Console.ReadLine()!);

            switch (opt)
            {
                case 1:
                    Console.Write("Nombre de Torneo ");
                    string? nombre = Console.ReadLine();
                    await service.RegistrarTorneoAsync(nombre!);
                    break;

                case 2:
                    Console.Write("Ingrese el ID del torneo a buscar: ");
                    int id = int.Parse(Console.ReadLine()!);
                    Torneo? tournament = await service.ObtenerTorneoPorIdAsync(id);
                    if (tournament != null)
                        Console.WriteLine($"Nombre: {tournament.Nombre}");
                    else
                        Console.WriteLine("Torneo No Encontrado");
                    break;

                case 3:
                    Console.Write("ID del Torneo a Eliminar ");
                    int idDelTor = int.Parse(Console.ReadLine()!);
                    await service.EliminarTorneo(idDelTor);
                    Console.WriteLine("Torneo Eliminado.");
                    break;
                case 4:
                    Console.Write("ID de Torneo a Actualizar ");
                    int idUpTor = int.Parse(Console.ReadLine()!);
                    Console.Write("Nuevo Nombre: ");
                    string? nuevoNombre = Console.ReadLine();
                    await service.ActualizarTorneo(idUpTor, nuevoNombre!);
                    break;
                case 5:
                    salir = true;
                    break;
            } 
            
        }
    }
}
