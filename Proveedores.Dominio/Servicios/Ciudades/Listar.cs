
using Proveedores.Dominio.ObjetoValor;
using Proveedores.Dominio.Puerto.Repositorios;

namespace Proveedores.Dominio.Servicios.Ciudades
{
    public class Listar (ICiudadRepositorio ciudadRepositorio)
    {
        private readonly ICiudadRepositorio _ciudadRepositorio = ciudadRepositorio;
        public async Task<List<Ciudad>> Ejecutar()
        {
            return await _ciudadRepositorio.ListarCiudades();
        }

    }
}
