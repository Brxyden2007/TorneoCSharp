using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Equipos.Domain.Entities;

namespace TorneoCSharp.src.Modules.CuerposMedicos.Domain
{
    public class CuerpoMedico
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Especialidad { get; set; } = null!; // Ejemplo: Fisioterapeuta, Médico General
        public int EquipoId { get; set; } // Relación con Equipo
        public Equipo? Equipo { get; set; } // Navegación a la entidad Equipo, si es necesario
    }
}
