
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Proveedores.Aplicacion.Comun;
using Proveedores.Aplicacion.Proveedores.Comandos;
using Proveedores.Aplicacion.Proveedores.Consulta;
using Proveedores.Aplicacion.Proveedores.Dto;

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

        /// <summary>
        /// Listado de proveedores
        /// </summary>
        /// <response code="200"> 
        /// ListaProveedorOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpGet]
        [Route("Listar")]
        [ProducesResponseType(typeof(ListaProveedorOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> Listar()
        {
            var output = await _mediator.Send(new ProveedorListar());

            if (output.Resultado != Resultado.Error)
            {
                return Ok(output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Obtener un proveedor por su ID
        /// </summary>
        /// <response code="200"> 
        /// ProveedorOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpGet]
        [Route("Obtener")]
        [ProducesResponseType(typeof(ProveedorOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> Obtener([FromQuery] ProveedorPorId input)
        {
            var output = await _mediator.Send(input);

            if (output.Resultado != Resultado.Error)
            {
                return Ok(output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

    }
}
