
using System.Diagnostics.CodeAnalysis;
using Proveedores.Dominio.Entidades;
using Proveedores.Dominio.Puerto.Repositorios;
using Proveedores.Infraestructura.Adaptadores.RepositorioGenerico;

namespace Proveedores.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class ProveedorRepositorio : IProveedorRepositorio
    {
        private readonly IRepositorioBase<Proveedor> _repositorioProveedor;

        public ProveedorRepositorio(IRepositorioBase<Proveedor> repositorioProveedor)
        {
            _repositorioProveedor = repositorioProveedor;
        }

        public async Task Guardar(Proveedor proveedor)
        {
            await _repositorioProveedor.Guardar(proveedor);
        }

        public async Task<List<Proveedor>> ObtenerProveedores()
        {
            return await _repositorioProveedor.DarListado();   
        }

        public async Task<Proveedor> ObtenerProveedorPorId(Guid id)
        {
            return await _repositorioProveedor.BuscarPorLlave(id);
        }
    }
}
