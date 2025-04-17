
using MediatR;
using System.Diagnostics.CodeAnalysis;
using Proveedores.Aplicacion.Documentos.Dto;

namespace Proveedores.Aplicacion.Documentos.Consultas
{
    [ExcludeFromCodeCoverage]
    public record TiposDocumentoConsulta() : IRequest<ListaTipoDocumentosOut>;
    
}
