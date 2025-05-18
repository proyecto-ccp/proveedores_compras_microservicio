
using AutoMapper;
using MediatR;
using Proveedores.Aplicacion.Comun;
using Proveedores.Aplicacion.Proveedores.Dto;
using Proveedores.Dominio.Servicios.Proveedores;
using System.Net;

namespace Proveedores.Aplicacion.Proveedores.Consulta
{
    public class ProveedorListarHandler : IRequestHandler<ProveedorListar, ListaProveedorOut>
    {
        private readonly IMapper _mapper;
        private readonly Listar _servicio;
        public ProveedorListarHandler(Listar servicio, IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;
        }
        public async Task<ListaProveedorOut> Handle(ProveedorListar request, CancellationToken cancellationToken)
        {
            ListaProveedorOut output = new()
            {
                Proveedores = []
            };

            try 
            {
                var listaProveedores = await _servicio.Ejecutar() ?? [];

                if (listaProveedores.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No existen proveedores";
                    output.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    listaProveedores.ForEach(proveedor => output.Proveedores.Add(_mapper.Map<ProveedorDto>(proveedor)));
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
