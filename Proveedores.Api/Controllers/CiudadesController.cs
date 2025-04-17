using MediatR;
using Microsoft.AspNetCore.Mvc;
using Proveedores.Aplicacion.Ciudades.Consultas;
using Proveedores.Aplicacion.Ciudades.Dto;
using Proveedores.Aplicacion.Comun;

namespace Proveedores.Api.Controllers
{
    /// <summary>
    /// Controlador para gestionar las ciudades
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CiudadesController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// constructor
        /// </summary>
        public CiudadesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene la lista las ciudades
        /// </summary>
        /// <response code="200"> 
        /// ListaCiudadOut pendiente
        /// </response>
        [HttpGet]
        [Route("ListarCiudades")]
        [ProducesResponseType(typeof(ListaCiudadOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ListarCiudades()
        {
            var output = await _mediator.Send(new CiudadesConsulta());

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
