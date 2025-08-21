using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Modules.Torneos.Domain.Entities;
using TorneoCSharp.src.Modules.Equipos.Domain.Entities;

namespace TorneoCSharp.src.Modules.EquipoTorneo.Domain
{
    public class EquipoTorneo
    {
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; } = null!;
    
        public int TorneoId { get; set; }
        public Torneo Torneo { get; set; } = null!;
    }
}