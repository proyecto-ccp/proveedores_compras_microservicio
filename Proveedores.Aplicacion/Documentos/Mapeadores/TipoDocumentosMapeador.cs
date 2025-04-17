
using AutoMapper;
using Proveedores.Aplicacion.Documentos.Dto;

namespace Proveedores.Aplicacion.Documentos.Mapeadores
{
    public class TipoDocumentosMapeador : Profile     
    {
        public TipoDocumentosMapeador() 
        {
            CreateMap<Dominio.ObjetoValor.Documento, TipoDocumentosDto>().ReverseMap();

        }
    }
}
