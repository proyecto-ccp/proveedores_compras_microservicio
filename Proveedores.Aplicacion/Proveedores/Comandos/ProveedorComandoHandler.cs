
using AutoMapper;
using MediatR;
using Proveedores.Aplicacion.Comun;
using Proveedores.Dominio.Entidades;
using Proveedores.Dominio.ObjetoValor;
using Proveedores.Dominio.Puertos.Integraciones;
using Proveedores.Dominio.Servicios.Proveedores;
using System.Net;
using System.Text.Json;

namespace Proveedores.Aplicacion.Proveedores.Comandos
{
    public class ProveedorComandoHandler : IRequestHandler<ProveedorCrear, BaseOut>
    {
        private readonly IMapper _mapper;
        private readonly Registrar _registrarProveedor;
        private readonly IServicioAuditoriaApi _servicioAuditoriaApi;

        public ProveedorComandoHandler(IMapper mapper, Registrar registrarProveedor, IServicioAuditoriaApi servicioAuditoriaApi) 
        {
            _mapper = mapper;
            _registrarProveedor = registrarProveedor;
            _servicioAuditoriaApi = servicioAuditoriaApi;
        }
        public async Task<BaseOut> Handle(ProveedorCrear request, CancellationToken cancellationToken)
        {
            BaseOut output = new();
            try
            {
                var proveedorNuevo = _mapper.Map<Proveedor>(request);
                await _registrarProveedor.Ejecutar(proveedorNuevo);
                output.Mensaje = "Proveedor creado correctamente";
                output.Resultado = Resultado.Exitoso;
                output.Status = HttpStatusCode.Created;

                var inputAuditoria = _mapper.Map<Auditoria>(request);
                inputAuditoria.IdRegistro = proveedorNuevo.Id.ToString();
                inputAuditoria.Registro = JsonSerializer.Serialize(proveedorNuevo);
                _ = Task.Run(() => _servicioAuditoriaApi.RegistrarAuditoria(inputAuditoria), cancellationToken);
            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = string.Concat("Message: ", ex.Message, ex.InnerException is null ? "" : "-InnerException-" + ex.InnerException.Message);
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;
        }
    }

}
