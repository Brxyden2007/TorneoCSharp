using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Transferencias.Domain;

namespace TorneoCSharp.src.Modules.Transferencias.Application.Interfaces
{
    public interface ITransferenciaService
    {
        Task CompraJugadorAsync(string nombre, string paisEquipo, DateTime fechaCreacion);
        Task PrestarJugadorAsync(int id, string nuevoNombre, DateTime fechaCreacion, string paisEquipo);
        Task NotificacionTransferenciaAsync(int id);
        Task<IEnumerable<Transferencia>> ConsultarTransferenciaAsync();
    }
}