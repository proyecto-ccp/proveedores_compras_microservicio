
using AutoMapper;
using MediatR;
using Proveedores.Aplicacion.Comun;
using Proveedores.Aplicacion.Proveedores.Dto;
using Proveedores.Dominio.Servicios.Proveedores;
using System.Net;

namespace Proveedores.Aplicacion.Proveedores.Consulta
{
    public class ProveedorPorIdHandler : IRequestHandler<ProveedorPorId, ProveedorOut>
    {
        private readonly IMapper _mapper;
        private readonly Obtener _servicio;
        public ProveedorPorIdHandler(IMapper mapper, Obtener servicio)
        {
            _mapper = mapper;
            _servicio = servicio;
        }
        public async Task<ProveedorOut> Handle(ProveedorPorId request, CancellationToken cancellationToken)
        {
            var output = new ProveedorOut();
            
            try
            {
                var proveedor = await _servicio.Ejecutar(request.Id);

                if (proveedor is null)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No existen el proveedor";
                    output.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    output.Proveedor = _mapper.Map<ProveedorDto>(proveedor);
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Consulta exitosa";
                    output.Status = HttpStatusCode.OK;
                }

            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = ex.Message;
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;
        }
    }
}
