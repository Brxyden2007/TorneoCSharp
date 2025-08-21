using LigaTorneo.src.Shared.Context;
using TorneoCSharp.src.Modules.CuerposTecnicos.Application.Services;
using TorneoCSharp.src.Modules.CuerposTecnicos.Domain;

namespace TorneoCSharp.src.Modules.CuerposTecnicos.UI
{
    public class MenuCuerposTecnicos
    {
        private readonly CuerpoTecnicoService _service;

        public MenuCuerposTecnicos(AppDbContext context)
        {
            _service = new CuerpoTecnicoService(context);
        }

        public async Task RenderMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- Menu Cuerpos Técnicos ---");
                Console.WriteLine("1. Crear");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Editar");
                Console.WriteLine("4. Eliminar");
                Console.WriteLine("5. Volver");
                Console.Write("Opción: ");
                int op = int.Parse(Console.ReadLine()!);

                switch (op)
                {
                    case 1:
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine()!;
                        Console.Write("Rol: ");
                        string rol = Console.ReadLine()!;
                        Console.Write("EquipoId: ");
                        int eqId = int.Parse(Console.ReadLine()!);
                        await _service.Crear(new CuerpoTecnico { Nombre = nombre, Rol = rol, EquipoId = eqId });
                        Console.WriteLine("✔ Cuerpo técnico agregado.");
                        break;

                    case 2:
                        var lista = await _service.Listar();
                        foreach (var c in lista)
                            Console.WriteLine($"{c.Id} - {c.Nombre} ({c.Rol}) EquipoId: {c.EquipoId}");
                        break;

                    case 3:
                        Console.Write("Id a editar: ");
                        int idEd = int.Parse(Console.ReadLine()!);
                        var editar = await _service.BuscarPorId(idEd);
                        if (editar != null)
                        {
                            Console.Write("Nuevo nombre: ");
                            editar.Nombre = Console.ReadLine()!;
                            Console.Write("Nuevo rol: ");
                            editar.Rol = Console.ReadLine()!;
                            await _service.Editar(editar);
                            Console.WriteLine("✔ Editado con éxito.");
                        }
                        else Console.WriteLine("✘ No encontrado.");
                        break;

                    case 4:
                        Console.Write("Id a eliminar: ");
                        int idDel = int.Parse(Console.ReadLine()!);
                        await _service.Eliminar(idDel);
                        Console.WriteLine("✔ Eliminado con éxito.");
                        break;

                    case 5:
                        salir = true;
                        break;
                }
            }
        }
    }
}
