using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorneoCSharp.src.Modules.Equipos.Domain.Entities;

public class Equipo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
    public string Pais { get; set; } = string.Empty;
    /* public ICollection<Torneo> Torneos { get; set; } = new List<Torneo>();
    public ICollection<Jugador> Jugadores { get; set; } = new List<Jugador>(); */
    public string DirectorTecnico { get; set; } = string.Empty;
    public string AsistenteTecnico { get; set; } = string.Empty;
    public string EntrenadorPortero { get; set; } = string.Empty;
    public string PreparadorFisico { get; set; } = string.Empty;
    public string MedicoEquipo { get; set; } = string.Empty;
    public string Fisioterapeuta { get; set; } = string.Empty;
    public string Kinesologo { get; set; } = string.Empty;
    public string Nutricionista { get; set; } = string.Empty;
}
