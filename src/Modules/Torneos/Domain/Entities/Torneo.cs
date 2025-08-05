using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigaTorneo.src.Modules.Torneos.Domain.Entities;

public class Torneo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}
