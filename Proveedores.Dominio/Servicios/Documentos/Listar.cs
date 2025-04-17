
using Proveedores.Dominio.ObjetoValor;
using Proveedores.Dominio.Puerto.Repositorios;

namespace Proveedores.Dominio.Servicios.Documentos
{
    public class Listar(IDocumentoRepositorio documentoRepositorio)
    {
        private readonly IDocumentoRepositorio _documentoRepositorio = documentoRepositorio;

        public async Task<List<Documento>> Ejecutar()
        {
            return await _documentoRepositorio.ListarTiposDocumento();
        }

    }
}
