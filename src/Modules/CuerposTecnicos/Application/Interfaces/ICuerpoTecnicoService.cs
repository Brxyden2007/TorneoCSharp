using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TorneoCSharp.src.Modules.CuerposTecnicos.Domain;

namespace TorneoCSharp.src.Modules.CuerposTecnicos.Application.Interfaces
{
    public interface ICuerpoTecnicoService
    {
        Task Crear(CuerpoTecnico cuerpoTecnico);
        Task<List<CuerpoTecnico>> Listar();
        Task<CuerpoTecnico?> BuscarPorId(int id);
        Task Editar(CuerpoTecnico cuerpoTecnico);
        Task Eliminar(int id);
    }
}
