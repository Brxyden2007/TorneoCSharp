using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Transferencias.Domain;

namespace TorneoCSharp.src.Modules.Transferencias.Application.Interfaces
{
    public interface ITransferenciaRepository
    {
        Task<Transferencia?> GetByIdAsync(int id);
        Task<IEnumerable<Transferencia>> GetAllTransferenciasAsync();
        void Add(Transferencia transferencia);
        void Remove(Transferencia transferencia);
        void Update(Transferencia transferencia);
        Task SaveAsync();
    }
}