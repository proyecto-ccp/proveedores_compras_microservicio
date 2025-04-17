
using MediatR;
using Proveedores.Aplicacion.Ciudades.Dto;
using System.Diagnostics.CodeAnalysis;

namespace Proveedores.Aplicacion.Ciudades.Consultas
{
    [ExcludeFromCodeCoverage]
    public record CiudadesConsulta() : IRequest<ListaCiudadOut>;
    
}
