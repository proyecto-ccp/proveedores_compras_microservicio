
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Proveedores.Aplicacion.Comun;
using Proveedores.Aplicacion.Proveedores.Comandos;

namespace Proveedores.Api.Controllers
{
    /// <summary>
    /// Controlador de proveedores
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ProveedoresController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor del controlador
        /// </summary>
        public ProveedoresController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crea un proveedor nuevo 
        /// </summary>
        /// <response code="201"> 
        /// BaseOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpPost]
        [Route("Crear")]
        [ProducesResponseType(typeof(BaseOut), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> Crear([FromBody] ProveedorCrear producto)
        {
            var output = await _mediator.Send(producto);

            if (output.Resultado != Resultado.Error)
            {
                return Created(string.Empty, output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

    }
}
