
using Proveedores.Dominio.Entidades;
using Proveedores.Dominio.Puerto.Repositorios;

namespace Proveedores.Dominio.Servicios.Proveedores
{
    public class Listar(IProveedorRepositorio proveedorRepositorio)
    {
        private readonly IProveedorRepositorio _proveedorRepositorio = proveedorRepositorio;

        public async Task<List<Proveedor>> Ejecutar()
        {
            
            return await _proveedorRepositorio.ObtenerProveedores();
        }

    }
}
