
using Proveedores.Dominio.ObjetoValor;

namespace Proveedores.Dominio.Puerto.Repositorios
{
    public interface ICiudadRepositorio
    {
        public Task<Ciudad> ObtenerCiudadPorId(Guid id);
        public Task<List<Ciudad>> ListarCiudades();
    }
}
