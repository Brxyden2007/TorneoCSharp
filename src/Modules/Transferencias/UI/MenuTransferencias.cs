using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Shared.Context;
using TorneoCSharp.src.Modules.Transferencias.Application.Services;
using TorneoCSharp.src.Modules.Transferencias.Infrastructure;

namespace TorneoCSharp.src.Modules.Transferencias.UI;
public class MenuTransferencias
{
    private readonly AppDbContext _context;
    readonly TransferenciaRepository repo = null!;
    readonly TransferenciaService service = null!;
    public MenuTransferencias(AppDbContext context)
    {
        _context = context;
        repo = new TransferenciaRepository(context);
        service = new TransferenciaService(repo);
    }
    public async Task RenderMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== Menú de Transferencias ===");
            Console.WriteLine("1. Comprar Jugador");
            Console.WriteLine("2. Prestar Jugador");
            Console.WriteLine("3. Consultar Notificaciones de Transferencia");
            Console.WriteLine("4. Mandar Transferencia");
            Console.WriteLine("5. Salir al Menú Principal");
            Console.Write("Seleccione una opción: ");
            string opt = Console.ReadLine()!;

            switch (opt)
            {
                case "1":
                    Console.Clear();
                    // Lógica para comprar jugador
                    Console.WriteLine("Funcionalidad de comprar jugador no implementada aún.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    // Lógica para buscar transferencia
                    Console.WriteLine("Funcionalidad de prestar jugador.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    // Lógica para editar transferencia
                    Console.WriteLine("Funcionalidad de mirar notificaciones de transferencia.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    // Lógica para eliminar transferencia
                    Console.WriteLine("Funcionalidad de mandar transferencia.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
    

}