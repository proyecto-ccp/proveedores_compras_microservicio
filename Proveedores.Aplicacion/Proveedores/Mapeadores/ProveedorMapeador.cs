
using AutoMapper;
using Proveedores.Aplicacion.Proveedores.Comandos;
using Proveedores.Aplicacion.Proveedores.Dto;
using Proveedores.Dominio.Entidades;

namespace Proveedores.Aplicacion.Proveedores.Mapeadores
{
    public class ProveedorMapeador : Profile
    {
        public ProveedorMapeador()
        {
            CreateMap<Proveedor, ProveedorDto>().ReverseMap();
            CreateMap<ProveedorCrear, Proveedor>().ReverseMap();
        }

    }
}
