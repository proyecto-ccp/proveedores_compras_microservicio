using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Proveedores.Dominio.ObjetoValor;
using Proveedores.Infraestructura.Adaptadores.Configuraciones;
using Proveedores.Infraestructura.Configuraciones;
using Proveedores.Dominio.Entidades;

namespace Proveedores.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class ProveedoresDbContext : DbContext
    {
        public ProveedoresDbContext(DbContextOptions<ProveedoresDbContext> options): base(options){ }

        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoDocumentoConfiguracion());
            modelBuilder.ApplyConfiguration(new ProveedorConfiguracion());
            modelBuilder.ApplyConfiguration(new CiudadConfiguracion());

        }
    }
}
