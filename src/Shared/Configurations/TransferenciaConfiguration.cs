using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorneoCSharp.src.Modules.Transferencias.Domain;

namespace TorneoCSharp.src.Shared.Configurations;

public class TransferenciaConfiguration : IEntityTypeConfiguration<Transferencia>
{
    public void Configure(EntityTypeBuilder<Transferencia> builder)
    {
        builder.ToTable("transferencias");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.JugadorId)
            .HasColumnName("jugador_id")
            .IsRequired();
        builder.Property(t => t.EquipoOrigenId)
            .HasColumnName("equipo_origen_id")
            .IsRequired();
        builder.Property(t => t.EquipoDestinoId)
            .HasColumnName("equipo_destino_id")
            .IsRequired();
        builder.Property(t => t.FechaTransferencia)
            .HasColumnName("fecha_transferencia")
            .IsRequired()
            .HasColumnType("date");
        builder.Property(t => t.Monto)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
    }    
}
