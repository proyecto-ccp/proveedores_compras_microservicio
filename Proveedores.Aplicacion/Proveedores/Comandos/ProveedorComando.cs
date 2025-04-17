
using MediatR;
using Proveedores.Aplicacion.Comun;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Proveedores.Aplicacion.Proveedores.Comandos
{
    [ExcludeFromCodeCoverage]
    public record ProveedorCrear(

        [Required(ErrorMessage = "El campo IdTipoDocumento es obligatorio")]
        int IdTipoDocumento,
        [Required(ErrorMessage = "El campo NumeroDocumento es obligatorio")]
        string NumeroDocumento,
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        string Nombre,
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        [RegularExpression(@"\(\+\d{1,3}\) \d{3}-\d{3}-\d{4}",
        ErrorMessage = "El formato del teléfono no es válido. Ejemplo: (+1) 123-456-7890")]
        string Telefono,
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        string Correo,
        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        string Direccion,
        [Required(ErrorMessage = "El campo IdCiudad es obligatorio")]
        string IdCiudad
        ) : IRequest<BaseOut>;
    
}
