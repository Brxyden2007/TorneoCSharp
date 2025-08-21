using LigaTorneo.src.Modules.CuerposMedicos.UI;
using LigaTorneo.src.Modules.Torneos.Application;
using LigaTorneo.src.Modules.Torneos.Application.Services;
using LigaTorneo.src.Modules.Torneos.UI;
using LigaTorneo.src.Shared.Helpers;

using TorneoCSharp.src.Modules.CuerposTecnicos.UI;
using TorneoCSharp.src.Modules.Equipos.UI;
using TorneoCSharp.src.Modules.Estadisticas.UI;
using TorneoCSharp.src.Modules.Jugadores.UI;
using TorneoCSharp.src.Modules.Transferencias.UI;
using TorneoCSharp.src.Shared.Helpers;

var context = DbContextFactory.Create();
/*
string connStr = "server=localhost;database=torneodb;user=root;password=BRAYDEN714bRayden714;"; use esto para mysql, pero, sin embargo, al usar la migracion pierdo lo que hice anteriormente en la base de datos
var dbInit = new DatabaseInitializer(connStr);
        dbInit.CreateDatabase();
        dbInit.DropTablas();
        dbInit.CrearTablas(); */
bool salir = false;
while (!salir)
{   
    Console.Clear();
    Console.WriteLine("\n --- Menu Principal ---");
    Console.WriteLine("0. Crear Torneo");
    Console.WriteLine("1. Registrar Equipo");
    Console.WriteLine("2. Registrar Cuerpo Tecnico");
    Console.WriteLine("3. Registrar Cuerpo Medico");
    Console.WriteLine("4. Registrar Jugador");
    Console.WriteLine("5. Transferencias");
    Console.WriteLine("6. Estadisticas");
    Console.WriteLine("7. Salir");
    Console.Write("Opcion: ");
    int opm = int.Parse(Console.ReadLine()!);

    switch (opm)
    {
        case 0:
            Console.Clear();
            await new MenuTorneos(context).RenderMenu();
            Console.Clear();
            break;
        case 1:
            Console.Clear();
            await new MenuEquipos(context).RenderMenu();
            Console.Clear();
            break;

        case 2: 
            Console.Clear();
            await new MenuCuerposTecnicos(context).RenderMenu();
            Console.Clear();
            break;

        case 3:
            Console.Clear();
            await new MenuCuerposMedicos(context).RenderMenu();
            Console.Clear();
            break;
        case 4:
            Console.Clear();
            await new MenuJugadores(context).RenderMenu();
            Console.Clear();
            break;
        case 5:
            Console.Clear();
            await new MenuTransferencias(context).RenderMenu();
            Console.Clear();
            break;
        case 6:
            Console.Clear();
            await new MenuEstadisticas(context).RenderMenu();
            Console.Clear();
            break;    
        case 7:
            salir = true;
            break;
        default:
            Console.WriteLine("Opcion Invalida, vuelva a introducir una opcion correcta.");
            break;
    }

}