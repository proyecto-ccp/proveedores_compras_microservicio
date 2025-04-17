
using Proveedores.Dominio.ObjetoValor;
using Proveedores.Dominio.Puerto.Repositorios;
using Proveedores.Infraestructura.Adaptadores.RepositorioGenerico;
using System.Diagnostics.CodeAnalysis;

namespace Proveedores.Infraestructura.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class CiudadRepositorio : ICiudadRepositorio
    {
        private readonly IRepositorioBase<Ciudad> _ciudad;

        public CiudadRepositorio(IRepositorioBase<Ciudad> ciudad)
        {
            _ciudad = ciudad;
        }

        public async Task<List<Ciudad>> ListarCiudades()
        {
            return await _ciudad.DarListado();
        }

        public async Task<Ciudad> ObtenerCiudadPorId(Guid id)
        {
            return await _ciudad.BuscarPorLlave(id);
        }
    }
}
