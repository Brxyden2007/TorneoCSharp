using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorneoCSharp.src.Modules.Jugadores.Domain.Entities
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Pais { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        // public int EquipoId { get; set; }
        // public Equipo? Equipo { get; set; }

    }
}