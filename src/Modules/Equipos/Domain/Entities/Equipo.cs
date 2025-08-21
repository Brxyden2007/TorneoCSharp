using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Modules.Torneos.Domain.Entities;
using TorneoCSharp.src.Modules.CuerposMedicos.Domain;
using TorneoCSharp.src.Modules.CuerposTecnicos.Domain;
using TorneoCSharp.src.Modules.Jugadores.Domain.Entities;

namespace TorneoCSharp.src.Modules.Equipos.Domain.Entities;

public class Equipo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
    public string Pais { get; set; } = string.Empty;
    // List<Torneo> Torneos { get; set; } = new List<Torneo>();
    // List<Jugador> Jugadores { get; set; } = new List<Jugador>();
    // Relación con Cuerpo Médico
    public ICollection<CuerpoTecnico> CuerposTecnicos { get; set; } = new List<CuerpoTecnico>();
    public ICollection<CuerpoMedico> CuerposMedicos { get; set; } = new List<CuerpoMedico>();
    // public ICollection<Jugador> Jugadores { get; set; } = new List<Jugador>();
    // CuerpoTecnico? CuerpoTecnico { get; set; }

    
}