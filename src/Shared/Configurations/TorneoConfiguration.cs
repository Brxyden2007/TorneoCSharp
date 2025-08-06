using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigaTorneo.src.Modules.Torneos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LigaTorneo.src.Shared.Configurations;

public class TorneoConfiguration : IEntityTypeConfiguration<Torneo>
{

    public void Configure(EntityTypeBuilder<Torneo> builder)
    {
        builder.ToTable("torneo");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(t => t.FechaInicio)
                .IsRequired()
                .HasColumnType("date");

        builder.Property(t => t.FechaFin)
                .IsRequired()
                .HasColumnType("date");
    }    
}
