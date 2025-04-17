

using System.Diagnostics.CodeAnalysis;
using Proveedores.Dominio.ObjetoValor;
using Proveedores.Dominio.Puerto.Repositorios;
using Proveedores.Infraestructura.Adaptadores.RepositorioGenerico;

namespace Proveedores.Infraestructura.Adaptadores.Repositorios
{
    [ExcludeFromCodeCoverage]
    public class DocumentosRepositorio : IDocumentoRepositorio
    {
        private readonly IRepositorioBase<Documento> _documento;

        public DocumentosRepositorio(IRepositorioBase<Documento> documento)
        {
            _documento = documento;
        }

        public async Task<List<Documento>> ListarTiposDocumento()
        {
            return await _documento.DarListado();
        }

        public async Task<Documento> ObtenerDocumentoPorId(int tipoDocumento)
        {
            return await _documento.BuscarPorLlave(tipoDocumento);
        }
    }
}
