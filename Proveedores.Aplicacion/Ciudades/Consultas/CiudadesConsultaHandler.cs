
using AutoMapper;
using MediatR;
using Proveedores.Aplicacion.Ciudades.Dto;
using Proveedores.Aplicacion.Comun;
using Proveedores.Dominio.Servicios.Ciudades;
using System.Net;

namespace Proveedores.Aplicacion.Ciudades.Consultas
{
    public class CiudadesConsultaHandler : IRequestHandler<CiudadesConsulta, ListaCiudadOut>
    {
        private readonly IMapper _mapper;
        private readonly Listar _listarCiudades;

        public CiudadesConsultaHandler(Listar listarCiudades, IMapper mapper)
        {
            _listarCiudades = listarCiudades;
            _mapper = mapper;
        }
        public async Task<ListaCiudadOut> Handle(CiudadesConsulta request, CancellationToken cancellationToken)
        {
            ListaCiudadOut output = new()
            {
                Ciudades = []
            };

            try
            {
                var ciudades = await _listarCiudades.Ejecutar() ?? [];

                if (ciudades.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No hay ciudades creadas";
                    output.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    ciudades.ForEach(ciudad => output.Ciudades.Add(_mapper.Map<CiudadDto>(ciudad)));
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
