
using AutoMapper;
using Proveedores.Aplicacion.Proveedores.Comandos;
using Proveedores.Aplicacion.Proveedores.Dto;
using Proveedores.Dominio.Entidades;
using Proveedores.Dominio.ObjetoValor;

namespace Proveedores.Aplicacion.Proveedores.Mapeadores
{
    public class ProveedorMapeador : Profile
    {
        public ProveedorMapeador()
        {
            CreateMap<Proveedor, ProveedorDto>().ReverseMap();
            CreateMap<ProveedorCrear, Proveedor>().ReverseMap();

            CreateMap<ProveedorCrear, Auditoria>()
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(dest => dest.Accion, opt => opt.MapFrom(src => "Proveedor creado"))
                .ForMember(dest => dest.TablaAfectada, opt => opt.MapFrom(src => "tbl_proveedores"));
        }

    }
}
