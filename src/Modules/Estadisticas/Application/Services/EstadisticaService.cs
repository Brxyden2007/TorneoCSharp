using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneoCSharp.src.Modules.Estadisticas.Domain.Entities;
using TorneoCSharp.src.Modules.Estadisticas.Infrastructure.Repositories;

namespace TorneoCSharp.src.Modules.Estadisticas.Application.Services
{
    public class EstadisticaService
    {
        public EstadisticaService(EstadisticaRepository repo)
        {
            // Initialize the EstadisticaService with the provided repository
            this.repo = repo;
        }
        private readonly EstadisticaRepository repo;
        public async Task<IEnumerable<Estadistica>> GetAllEstadisticasAsync()
        {
            // Retrieve all Estadisticas from the repository
            return await repo.GetAllEstadisticasAsync();
        }
        public async Task<Estadistica?> GetEstadisticaByIdAsync(int id)
        {
            // Retrieve a specific Estadistica by its ID
            return await repo.GetByIdAsync(id);
        }
        public async Task AddEstadisticaAsync(Estadistica estadistica)
        {
            // Add a new Estadistica to the repository
            repo.Add(estadistica);
            await repo.SaveAsync();
        }
        public async Task UpdateEstadisticaAsync(Estadistica estadistica)
        {
            // Update an existing Estadistica in the repository
            repo.Update(estadistica);
            await repo.SaveAsync();
        }
        public async Task DeleteEstadisticaAsync(int id)
        {
            // Delete an Estadistica by its ID
            var estadistica = await repo.GetByIdAsync(id);
            if (estadistica != null)
            {
                repo.Remove(estadistica);
                await repo.SaveAsync();
            }
            else
            {
                throw new Exception("Estadistica not found");
            }
        }
        public async Task SaveChangesAsync()
        {
            // Save changes to the repository
            await repo.SaveAsync();
        }
        public async Task NotificacionEstadisticaAsync(int id)
        {
            // Logic for notification of Estadistica
            var estadistica = await repo.GetByIdAsync(id);
            if (estadistica == null)
            {
                throw new Exception("Estadistica not found");
            }

        }
        public async Task MostrarEstadisticasAsync()
        {
            // Display all Estadisticas
            var estadisticas = await GetAllEstadisticasAsync();
            foreach (var estadistica in estadisticas)
            {
                Console.WriteLine($"ID: {estadistica.Id}, Nombre: {estadistica.Nombre}, Valor: {estadistica.Valor}");
            }
        }
        public async Task MostrarEstadisticaPorIdAsync(int id)
        {
            // Display a specific Estadistica by its ID
            var estadistica = await GetEstadisticaByIdAsync(id);
            if (estadistica != null)
            {
                Console.WriteLine($"ID: {estadistica.Id}, Nombre: {estadistica.Nombre}, Valor: {estadistica.Valor}");
            }
            else
            {
                Console.WriteLine("Estadistica not found");
            }
        }
        public async Task RegistrarEstadisticaAsync(int id, string nombre, double valor, DateTime fechaCreacion, string descripcion)
        {
            // Register a new Estadistica
            var estadistica = new Estadistica(id, nombre, valor, descripcion)
            {
                FechaCreacion = fechaCreacion
            };
            await AddEstadisticaAsync(estadistica);
        }

        public async Task ActualizarEstadisticaAsync(int id, string nuevoNombre, double nuevoValor)
        {
            // Update an existing Estadistica
            var estadistica = await GetEstadisticaByIdAsync(id);
            if (estadistica == null)
            {
                throw new Exception($"Estadistica with ID {id} not found.");
            }
            estadistica.Nombre = nuevoNombre;
            estadistica.Valor = nuevoValor;
            await UpdateEstadisticaAsync(estadistica);
        }
        public async Task EliminarEstadisticaAsync(int id)
        {
            // Delete an Estadistica by its ID
            var estadistica = await GetEstadisticaByIdAsync(id);
            if (estadistica == null)
            {
                throw new Exception($"Estadistica with ID {id} not found.");
            }
            await DeleteEstadisticaAsync(id);
        }
        public async Task<IEnumerable<Estadistica>> ConsultarEstadisticasAsync()
        {
            // Retrieve all Estadisticas
            return await GetAllEstadisticasAsync();
        }
        
    }
}