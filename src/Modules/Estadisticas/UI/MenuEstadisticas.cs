using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Shared.Context;
using TorneoCSharp.src.Modules.Estadisticas.Application.Services;
using TorneoCSharp.src.Modules.Estadisticas.Infrastructure.Repositories;

namespace TorneoCSharp.src.Modules.Estadisticas.UI;

public class MenuEstadisticas
{
    private readonly AppDbContext _context;
readonly EstadisticaRepository repo = null!;
readonly EstadisticaService service = null!;
public MenuEstadisticas(AppDbContext context)
{
    _context = context;
    repo = new EstadisticaRepository(context);
    service = new EstadisticaService(repo);
}
    public async Task RenderMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Menú de Estadísticas");
            Console.WriteLine("1. Jugador Con Mas Asistencias Torneo");
            Console.WriteLine("2. Equipo Con Mas Goles En Contra Torneo");
            Console.WriteLine("3. Jugadores Mas Caros Por Equipo");
            Console.WriteLine("4. Jugadores Menores Al promedio de Edad del Equipo");
            Console.WriteLine("5. Salir al Menú Principal");
            Console.Write("Seleccione una opción: ");
            var opeq = Console.ReadLine();
            switch (opeq)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Jugador con más asistencias en el torneo seleccionado.");
                    
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Equipo con más goles en contra en el torneo seleccionado.");
                    // Lógica para mostrar equipo con más goles en contra
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Jugadores más caros por equipo.");
                    // Lógica para mostrar jugadores más caros por equipo
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Jugadores menores al promedio de edad del equipo.");
                    // Lógica para mostrar jugadores menores al promedio de edad del equipo
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }  
        }
    }
}
