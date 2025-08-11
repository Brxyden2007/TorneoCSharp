using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorneoCSharp.src.Modules.Transferencias.Application.Services
{
    public class TransferenciaService
    {
        private readonly Application.Interfaces.ITransferenciaRepository _repository;

        public TransferenciaService(Application.Interfaces.ITransferenciaRepository repository)
        {
            _repository = repository;
        }

        public async Task CompraJugadorAsync(string nombre, string paisEquipo, DateTime fechaCreacion)
        {
            var transferencia = new Domain.Transferencia
            {
                // Inicializar propiedades según sea necesario
            };

            _repository.Add(transferencia);
            await _repository.SaveAsync();
        }

        public async Task PrestarJugadorAsync(int id, string nuevoNombre, DateTime fechaCreacion, string paisEquipo)
        {
            var transferencia = await _repository.GetByIdAsync(id);
            if (transferencia == null)
            {
                throw new Exception("Transferencia no encontrada");
            }

            // Actualizar propiedades según sea necesario

            _repository.Update(transferencia);
            await _repository.SaveAsync();
        }

        public async Task NotificacionTransferenciaAsync(int id)
        {
            var transferencia = await _repository.GetByIdAsync(id);
            if (transferencia == null)
            {
                throw new Exception("Transferencia no encontrada");
            }

            // Lógica para notificación de transferencia
        }

        public async Task<IEnumerable<Domain.Transferencia>> ConsultarTransferenciaAsync()
        {
            return await _repository.GetAllTransferenciasAsync();
        }
        
    }
}