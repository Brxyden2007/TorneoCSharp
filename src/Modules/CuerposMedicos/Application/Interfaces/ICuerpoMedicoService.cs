using System.Collections.Generic;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.CuerposMedicos.Domain;

namespace LigaTorneo.src.Modules.CuerposMedicos.Application.Interfaces
{
    public interface ICuerpoMedicoService
    {
        Task CrearCuerpoMedico(CuerpoMedico medico);
        Task<IEnumerable<CuerpoMedico>> ListarCuerposMedicos();
        Task<CuerpoMedico?> ObtenerPorId(int id);
        Task ActualizarCuerpoMedico(CuerpoMedico medico);
        Task EliminarCuerpoMedico(int id);
    }
}
