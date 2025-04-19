
using Proveedores.Aplicacion.Comun;
using System.Diagnostics.CodeAnalysis;

namespace Proveedores.Aplicacion.Proveedores.Dto
{
    [ExcludeFromCodeCoverage]
    public class ProveedorDto
    {
        public Guid Id { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public Guid IdCiudad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProveedorOut : BaseOut
    {
        public ProveedorDto Proveedor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ListaProveedorOut : BaseOut
    {
        public List<ProveedorDto> Proveedores { get; set; }
    }
}
