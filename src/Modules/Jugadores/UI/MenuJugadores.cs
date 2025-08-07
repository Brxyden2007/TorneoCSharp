using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using TorneoCSharp.src.Modules.Jugadores.Application.Interfaces;
using TorneoCSharp.src.Modules.Jugadores.Application.Services;
using TorneoCSharp.src.Modules.Jugadores.Infrastructure.Repositories;

namespace TorneoCSharp.src.Modules.Jugadores.UI;
    public class MenuJugadores
    {
       private readonly AppDbContext _context;
        readonly JugadorRepository repo = null!;
        readonly JugadorService service = null!;
        public MenuJugadores(AppDbContext context)
        {
            _context = context;
            repo = new JugadorRepository(context);
            service = new JugadorService(repo);
        }
        public async Task RenderMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("=== Menú de Jugadores ===");
                Console.WriteLine("1. Registrar Jugador");
                Console.WriteLine("2. Buscar Jugador");
                Console.WriteLine("3. Editar Jugador");
                Console.WriteLine("4. Eliminar Jugador");
                Console.WriteLine("5. Salir al Menú Principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine()!;

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Registrar Jugador seleccionado.");
                        await service.RegistrarJugadorAsync("Lionel Messi", "Delantero", "Argentina", new DateTime(1987, 6, 24), 34);
                        Console.WriteLine("Jugador registrado correctamente.");

                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Buscar Jugador seleccionado.");

                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Editar Jugador seleccionado.");

                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Eliminar Jugador seleccionado.");
                        break;
                    case "5":
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