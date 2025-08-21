using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Equipos.Domain.Entities;

namespace TorneoCSharp.src.Modules.CuerposTecnicos.Domain
{
    public class CuerpoTecnico
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Rol { get; set; } = null!; // Ejemplo: DT, Preparador Físico, etc.
        public int EquipoId { get; set; } // Relación con Equipo
        public Equipo? Equipo { get; set; } // Navegación a la entidad Equipo, si es necesario
    }
}