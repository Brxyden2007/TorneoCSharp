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
            builder.ToTable("equipos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Pais)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.FechaCreacion)
                .IsRequired()
                .HasColumnType("date");

            /*builder.HasOne(e => e.CuerpoMedico)
                .WithMany()
                .HasForeignKey(e => e.CuerpoMedicoId)
                .HasColumnName("cuerpo_medico_id")
                .OnDelete(DeleteBehavior.Cascade);
                 // Configura la eliminación en cascada si se elimina el equipo
            builder.HasOne(e => e.CuerpoTecnico)
                .WithMany()
                .HasForeignKey(e => e.CuerpoTecnicoId)
                .HasColumnName("cuerpo_tecnico_id")
                .OnDelete(DeleteBehavior.Cascade); // Configura la eliminación en cascada si se elimina el equipo*/
        }
    }
}