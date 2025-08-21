using LigaTorneo.src.Modules.CuerposMedicos.Application.Services;
using LigaTorneo.src.Shared.Context;
using TorneoCSharp.src.Modules.CuerposMedicos.Domain;

namespace LigaTorneo.src.Modules.CuerposMedicos.UI
{
    public class MenuCuerposMedicos
    {
        private readonly CuerpoMedicoService _service;

        public MenuCuerposMedicos(AppDbContext context)
        {
            _service = new CuerpoMedicoService(context);
        }

        public async Task RenderMenu()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("\n --- Menú Cuerpo Médico ---");
                Console.WriteLine("1. Registrar Cuerpo Médico");
                Console.WriteLine("2. Listar Cuerpos Médicos");
                Console.WriteLine("3. Actualizar Cuerpo Médico");
                Console.WriteLine("4. Eliminar Cuerpo Médico");
                Console.WriteLine("5. Volver al Menú Principal");
                Console.Write("Opción: ");

                int op = int.Parse(Console.ReadLine()!);

                switch (op)
                {
                    case 1:
                        await RegistrarCuerpoMedico();
                        break;
                    case 2:
                        await ListarCuerposMedicos();
                        break;
                    case 3:
                        await ActualizarCuerpoMedico();
                        break;
                    case 4:
                        await EliminarCuerpoMedico();
                        break;
                    case 5:
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

                if (!volver)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        private async Task RegistrarCuerpoMedico()
        {
            Console.WriteLine("\n--- Registrar Cuerpo Médico ---");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine()!;
            Console.Write("Especialidad: ");
            string especialidad = Console.ReadLine()!;
            Console.Write("ID Equipo: ");
            int equipoId = int.Parse(Console.ReadLine()!);

            var medico = new CuerpoMedico
            {
                Nombre = nombre,
                Especialidad = especialidad,
                EquipoId = equipoId
            };

            await _service.CrearCuerpoMedico(medico);
            Console.WriteLine("Cuerpo Médico registrado con éxito.");
        }

        private async Task ListarCuerposMedicos()
        {
            Console.WriteLine("\n--- Lista de Cuerpos Médicos ---");
            var medicos = await _service.ListarCuerposMedicos();

            foreach (var m in medicos)
            {
                Console.WriteLine($"ID: {m.Id} | Nombre: {m.Nombre} | Especialidad: {m.Especialidad} | EquipoId: {m.EquipoId}");
            }
        }

        private async Task ActualizarCuerpoMedico()
        {
            Console.Write("\nIngrese el ID del Cuerpo Médico a actualizar: ");
            int id = int.Parse(Console.ReadLine()!);

            var medico = await _service.ObtenerPorId(id);
            if (medico == null)
            {
                Console.WriteLine("No se encontró el Cuerpo Médico.");
                return;
            }

            Console.Write($"Nuevo Nombre ({medico.Nombre}): ");
            string nombre = Console.ReadLine()!;
            Console.Write($"Nueva Especialidad ({medico.Especialidad}): ");
            string especialidad = Console.ReadLine()!;
            Console.Write($"Nuevo EquipoId ({medico.EquipoId}): ");
            string equipoIdStr = Console.ReadLine()!;

            if (!string.IsNullOrEmpty(nombre)) medico.Nombre = nombre;
            if (!string.IsNullOrEmpty(especialidad)) medico.Especialidad = especialidad;
            if (int.TryParse(equipoIdStr, out int equipoId)) medico.EquipoId = equipoId;

            await _service.ActualizarCuerpoMedico(medico);
            Console.WriteLine("Cuerpo Médico actualizado con éxito.");
        }

        private async Task EliminarCuerpoMedico()
        {
            Console.Write("\nIngrese el ID del Cuerpo Médico a eliminar: ");
            int id = int.Parse(Console.ReadLine()!);

            await _service.EliminarCuerpoMedico(id);
            Console.WriteLine("Cuerpo Médico eliminado con éxito.");
        }
    }
}
