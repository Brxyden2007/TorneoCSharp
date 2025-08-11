using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using LigaTorneo.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using TorneoCSharp.src.Modules.Transferencias.Application.Interfaces;
using TorneoCSharp.src.Modules.Transferencias.Domain;

namespace TorneoCSharp.src.Modules.Transferencias.Infrastructure
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly AppDbContext _context;

        public TransferenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Transferencia?> GetByIdAsync(int id)
        {
            return await _context.Transferencias
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Transferencia>> GetAllEquiposAsync() =>
            // Implementation to get all Equipos
            await _context.Transferencias.ToListAsync();

        public void Add(Transferencia transferencia) =>
        _context.Transferencias.Add(transferencia);
        

        public void Remove(Transferencia transferencia) =>
        _context.Transferencias.Remove(transferencia);
        

        public void Update(Transferencia transferencia) =>
        _context.Transferencias.Update(transferencia);
        

        public async Task SaveAsync() =>
        await _context.SaveChangesAsync();

        public Task<IEnumerable<Transferencia>> GetAllTransferenciasAsync()
        {
            throw new NotImplementedException();
        }
    }
}