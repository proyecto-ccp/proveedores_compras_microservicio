
using System.Diagnostics.CodeAnalysis;

namespace Proveedores.Dominio.Entidades
{
    [ExcludeFromCodeCoverage]
    public class Proveedor : EntidadBaseGuid
    {
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public Guid IdCiudad { get; set; }

    }
}
