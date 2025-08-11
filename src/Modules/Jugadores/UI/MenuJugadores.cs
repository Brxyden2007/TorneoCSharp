using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using TorneoCSharp.src.Modules.Jugadores.Application.Interfaces;
using TorneoCSharp.src.Modules.Jugadores.Application.Services;
using TorneoCSharp.src.Modules.Jugadores.Domain.Entities;
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
                Console.Clear();
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
                        Console.Write("Ingrese el nombre del jugador: ");
                        string nombre = Console.ReadLine()!;
                        Console.Write("Ingrese el apellido del jugador: ");
                        string apellido = Console.ReadLine()!;
                        Console.Write("Ingrese la edad del jugador: ");
                        int edad = int.Parse(Console.ReadLine()!);
                        Console.Write("Ingrese el país del jugador: ");
                        string pais = Console.ReadLine()!;
                        Console.Write("Ingrese la posición del jugador: ");
                        string posicion = Console.ReadLine()!;
                        Console.Write("Ingrese el dorsal del jugador: ");
                        int dorsal = int.Parse(Console.ReadLine()!);
                        await service.RegistrarJugadorAsync(nombre, apellido, edad, pais, posicion, dorsal);
                        Console.WriteLine("Jugador registrado exitosamente.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                    break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Buscar Jugador seleccionado.");
                        Console.Write("Ingrese el ID del jugador a buscar: ");
                        int id = int.Parse(Console.ReadLine()!);
                        Jugador? jugador = await service.ObtenerJugadorPorIdAsync(id);
                        if (jugador != null)
                        {
                            Console.WriteLine($"ID: {jugador.Id}, Nombre: {jugador.Nombre}, Apellido: {jugador.Apellido}, Edad: {jugador.Edad}, País: {jugador.Pais}, Posición: {jugador.Posicion}, Dorsal: {jugador.Dorsal}");
                        }
                        else
                        {
                            Console.WriteLine("Jugador no encontrado.");
                        }
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Editar Jugador seleccionado.");
                        Console.Write("Ingrese el ID del jugador a editar: ");
                        int idEditar = int.Parse(Console.ReadLine()!);
                        Jugador? jugadorEditar = await service.ObtenerJugadorPorIdAsync(idEditar);
                        if (jugadorEditar != null)
                        {
                            Console.Write("Ingrese el nuevo nombre del jugador: ");
                            string nuevoNombre = Console.ReadLine()!;
                            Console.Write("Ingrese el nuevo apellido del jugador: ");
                            string nuevoApellido = Console.ReadLine()!;
                            Console.Write("Ingrese la nueva edad del jugador: ");
                            int nuevaEdad = int.Parse(Console.ReadLine()!);
                            Console.Write("Ingrese el nuevo país del jugador: ");
                            string nuevoPais = Console.ReadLine()!;
                            Console.Write("Ingrese la nueva posición del jugador: ");
                            string nuevaPosicion = Console.ReadLine()!;
                            Console.Write("Ingrese el nuevo dorsal del jugador: ");
                            int nuevoDorsal = int.Parse(Console.ReadLine()!);
                            await service.ActualizarJugadorAsync(idEditar, nuevoNombre, nuevoApellido, nuevaEdad, nuevoPais, nuevaPosicion, nuevoDorsal);
                            Console.WriteLine("Jugador actualizado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Jugador no encontrado.");
                        }
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Eliminar Jugador seleccionado.");
                        Console.Write("Ingrese el ID del jugador a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine()!);
                        Jugador? jugadorEliminar = await service.ObtenerJugadorPorIdAsync(idEliminar);
                        if (jugadorEliminar != null)
                        {
                            await service.EliminarJugadorAsync(idEliminar);
                            Console.WriteLine("Jugador eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Jugador no encontrado.");
                        }
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
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