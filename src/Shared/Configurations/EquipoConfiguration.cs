using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorneoCSharp.src.Modules.Equipos.Domain.Entities;

namespace TorneoCSharp.src.Shared.Configurations
{
    public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {
            builder.ToTable("equipo");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.FechaCreacion)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(e => e.Pais)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.DirectorTecnico)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.AsistenteTecnico)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.EntrenadorPortero)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.PreparadorFisico)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.MedicoEquipo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Fisioterapeuta)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Kinesologo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Nutricionista)
                .IsRequired()
                .HasMaxLength(100);    
        }
    }
}