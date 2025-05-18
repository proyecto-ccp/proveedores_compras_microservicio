

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proveedores.Dominio.Entidades;
using System.Diagnostics.CodeAnalysis;

namespace Proveedores.Infraestructura.Adaptadores.Configuraciones
{
    [ExcludeFromCodeCoverage]
    public class ProveedorConfiguracion : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("tbl_proveedores");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Direccion)
                .HasColumnName("direccion")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Correo)
                .HasColumnName("correo")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Telefono)
               .HasColumnName("telefono")
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(x => x.FechaCreacion)
                .HasColumnName("fecharegistro")
                .HasColumnType("timestamp(6)")
                .IsRequired();

            builder.Property(x => x.FechaModificacion)
                .HasColumnName("fechaactualizacion")
                .HasColumnType("timestamp(6)")
                .IsRequired(false);

            builder.HasIndex(x => x.Nombre)
                .IsUnique();

            builder.Property(x => x.IdTipoDocumento)
                .HasColumnName("idtipodocumento")
                .IsRequired();

            builder.Property(x => x.NumeroDocumento)
                .HasColumnName("numerodocumento")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.IdCiudad)
                .HasColumnName("idciudad")
                .IsRequired();

        }
    }
}
