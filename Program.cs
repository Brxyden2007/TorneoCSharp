using LigaTorneo.src.Modules.Torneos.Application;
using LigaTorneo.src.Modules.Torneos.Application.Services;
using LigaTorneo.src.Modules.Torneos.UI;
using LigaTorneo.src.Shared.Helpers;

var context = DbContextFactory.Create();

bool salir = false;
while (!salir)
{
    Console.WriteLine("\n --- Menu Principal ---");
    Console.WriteLine("0. Crear Torneo");
    Console.WriteLine("5. Salir");
    Console.Write("Opcion: ");
    int opm = int.Parse(Console.ReadLine()!);

    switch (opm)
    {
        case 0:
            await new MenuTorneos(context).RenderMenu();
            break;
        case 1:
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;    
        case 5:
            salir = true;
            break;
        default:
            Console.WriteLine("Opcion Invalida, vuelva a introducir una opcion correcta.");
            break;
    }

}