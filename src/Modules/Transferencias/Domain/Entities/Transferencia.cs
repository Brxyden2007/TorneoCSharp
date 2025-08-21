using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorneoCSharp.src.Modules.Transferencias.Domain
{
    public class Transferencia
    {
        public int Id { get; set; }
        public int JugadorId { get; set; } // Relación con Jugador
        public int EquipoOrigenId { get; set; } // Relación con Equipo de origen
        public int EquipoDestinoId { get; set; } // Relación con Equipo de destino
        public DateTime FechaTransferencia { get; set; }
        public decimal Monto { get; set; } // Monto de la transferencia
    }
}