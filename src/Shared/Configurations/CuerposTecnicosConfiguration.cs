using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorneoCSharp.src.Modules.CuerposTecnicos.Domain;

namespace TorneoCSharp.src.Modules.CuerposTecnicos.Infrastructure.Persistence.Configurations
{
    public class CuerpoTecnicoConfiguration : IEntityTypeConfiguration<CuerpoTecnico>
    {
        public void Configure(EntityTypeBuilder<CuerpoTecnico> builder)
        {
            builder.ToTable("cuerpostecnicos");

            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.Id)
                .HasColumnName("id");

            builder.Property(ct => ct.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nombre");

            builder.Property(ct => ct.Rol)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("rol");

            builder.Property(ct => ct.EquipoId)
                .HasColumnName("equipo_id");

            builder.HasOne(ct => ct.Equipo)
                .WithMany(e => e.CuerposTecnicos)
                .HasForeignKey(ct => ct.EquipoId);
        }
    }
}
