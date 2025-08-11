using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LigaTorneo.src.Modules.Torneos.Domain.Entities;
using TorneoCSharp.src.Modules.Equipos.Domain.Entities;
using TorneoCSharp.src.Modules.Jugadores.Domain.Entities;
using TorneoCSharp.src.Modules.Transferencias.Domain;
using TorneoCSharp.src.Modules.Estadisticas.Domain.Entities;
namespace LigaTorneo.src.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Torneo> Torneos { get; set; } = null!;
    public DbSet<Equipo> Equipos { get; set; } = null!;
    public DbSet<Jugador> Jugadores { get; set; } = null!;
    public DbSet<Transferencia> Transferencias { get; set; } = null!;
    public DbSet<Estadistica> Estadisticas { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    
}
