using Proveedores.Dominio.ObjetoValor;

namespace Proveedores.Dominio.Puertos.Integraciones
{
    public interface IServicioAuditoriaApi
    {
        Task RegistrarAuditoria(Auditoria auditoria);
    }
}
