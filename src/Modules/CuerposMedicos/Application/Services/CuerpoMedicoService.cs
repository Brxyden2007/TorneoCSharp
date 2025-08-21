using LigaTorneo.src.Modules.CuerposMedicos.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using LigaTorneo.src.Shared.Context;
using TorneoCSharp.src.Modules.CuerposMedicos.Domain;

namespace LigaTorneo.src.Modules.CuerposMedicos.Application.Services
{
    public class CuerpoMedicoService : ICuerpoMedicoService
    {
        private readonly AppDbContext _context;

        public CuerpoMedicoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CrearCuerpoMedico(CuerpoMedico medico)
        {
            _context.CuerposMedicos.Add(medico);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CuerpoMedico>> ListarCuerposMedicos()
        {
            return await _context.CuerposMedicos.ToListAsync();
        }

        public async Task<CuerpoMedico?> ObtenerPorId(int id)
        {
            return await _context.CuerposMedicos.FindAsync(id);
        }

        public async Task ActualizarCuerpoMedico(CuerpoMedico medico)
        {
            _context.CuerposMedicos.Update(medico);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarCuerpoMedico(int id)
        {
            var medico = await _context.CuerposMedicos.FindAsync(id);
            if (medico != null)
            {
                _context.CuerposMedicos.Remove(medico);
                await _context.SaveChangesAsync();
            }
        }
    }
}
