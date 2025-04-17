
using Proveedores.Aplicacion.Comun;
using System.Diagnostics.CodeAnalysis;

namespace Proveedores.Aplicacion.Ciudades.Dto
{
    [ExcludeFromCodeCoverage]
    public class CiudadDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class CiudadOut : BaseOut
    {
        public CiudadDto Ciudad { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ListaCiudadOut : BaseOut
    {
        public List<CiudadDto> Ciudades { get; set; }
    }
}
