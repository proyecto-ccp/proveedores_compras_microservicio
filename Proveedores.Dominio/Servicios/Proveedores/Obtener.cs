
using Proveedores.Dominio.Entidades;
using Proveedores.Dominio.Puerto.Repositorios;

namespace Proveedores.Dominio.Servicios.Proveedores
{
    public class Obtener(IProveedorRepositorio proveedorRepositorio)
    {
        private readonly IProveedorRepositorio _proveedorRepositorio = proveedorRepositorio;

        public async Task<Proveedor> Ejecutar(Guid id)
        {

            return await _proveedorRepositorio.ObtenerProveedorPorId(id);
        }

    }
}
