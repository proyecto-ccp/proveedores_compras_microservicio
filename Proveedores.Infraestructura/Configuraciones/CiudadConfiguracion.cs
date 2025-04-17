
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proveedores.Dominio.ObjetoValor;
using System.Diagnostics.CodeAnalysis;

namespace Proveedores.Infraestructura.Configuraciones
{
    [ExcludeFromCodeCoverage]
    public class CiudadConfiguracion : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.ToView("vw_datosubicacion");
            builder.Property(c => c.Id).HasColumnName("idciudad");
            builder.Property(c => c.Nombre).HasColumnName("ciudad");

        }
    }
}
