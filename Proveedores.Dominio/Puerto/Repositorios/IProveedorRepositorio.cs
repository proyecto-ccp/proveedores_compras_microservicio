
using Proveedores.Dominio.Entidades;

namespace Proveedores.Dominio.Puerto.Repositorios
{
    public interface IProveedorRepositorio
    {
        Task Guardar(Proveedor proveedor);
    }
}
