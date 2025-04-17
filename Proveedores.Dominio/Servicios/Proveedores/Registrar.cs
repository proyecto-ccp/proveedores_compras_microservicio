
using Proveedores.Dominio.Entidades;
using Proveedores.Dominio.ObjetoValor;
using Proveedores.Dominio.Puerto.Repositorios;

namespace Proveedores.Dominio.Servicios.Proveedores
{
    public class Registrar(IDocumentoRepositorio documentoRepositorio, ICiudadRepositorio ciudadRepositorio, IProveedorRepositorio proveedorRepositorio)
    {
        private readonly IDocumentoRepositorio _documentoRepositorio = documentoRepositorio;
        private readonly ICiudadRepositorio _ciudadRepositorio = ciudadRepositorio;
        private readonly IProveedorRepositorio _proveedorRepositorio = proveedorRepositorio;

        private readonly string _paramErrorTipoDocumento = "TipoDocumento";
        private readonly string _paramErrorCiudad = "Ciudad";

        public async Task Ejecutar(Proveedor proveedor)
        {
            var documento = await EstablecerDocumento(proveedor);
            proveedor.IdTipoDocumento = documento.Id;
            var ciudad = await EstablecerCiudad(proveedor);
            proveedor.IdCiudad = ciudad.Id;
            proveedor.Id = Guid.NewGuid();
            proveedor.FechaCreacion = DateTime.Now;
            await _proveedorRepositorio.Guardar(proveedor);
        }

        private async Task<Documento> EstablecerDocumento(Proveedor proveedor)
        {
            var tipoDocumento = await _documentoRepositorio.ObtenerDocumentoPorId(proveedor.IdTipoDocumento) ?? throw new ArgumentNullException(_paramErrorTipoDocumento, "El tipo de documento no existe");
            return tipoDocumento;
        }

        private async Task<Ciudad> EstablecerCiudad(Proveedor proveedor)
        {
            var ciudad = await _ciudadRepositorio.ObtenerCiudadPorId(proveedor.IdCiudad) ?? throw new ArgumentNullException(_paramErrorCiudad, "La ciudad no existe");
            return ciudad;
        }

    }
}
