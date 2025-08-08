using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorneoCSharp.src.Modules.Jugadores.Domain.Entities;

namespace TorneoCSharp.src.Shared.Configurations;

public class JugadorConfiguration : IEntityTypeConfiguration<Jugador>
{
    public void Configure(EntityTypeBuilder<Jugador> builder)
    {
        builder.ToTable("jugador");
        builder.HasKey(j => j.Id);
        builder.Property(j => j.Nombre)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(j => j.Apellido)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(j => j.Edad)
            .IsRequired()
            .HasColumnType("int")
            .HasMaxLength(3);
        builder.Property(j => j.Pais)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(j => j.Posicion)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(j => j.Dorsal)
            .IsRequired()
            .HasMaxLength(3);
    }
}
