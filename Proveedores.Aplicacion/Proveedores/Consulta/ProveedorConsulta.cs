
using MediatR;
using Proveedores.Aplicacion.Proveedores.Dto;
using System.Diagnostics.CodeAnalysis;

namespace Proveedores.Aplicacion.Proveedores.Consulta
{
    [ExcludeFromCodeCoverage]
    public record ProveedorListar() : IRequest<ListaProveedorOut>;
    
    [ExcludeFromCodeCoverage]
    public record ProveedorPorId(Guid Id) : IRequest<ProveedorOut>;


}
