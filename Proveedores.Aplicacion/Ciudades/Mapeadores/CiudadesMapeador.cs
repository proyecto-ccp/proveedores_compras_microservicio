
using AutoMapper;
using Proveedores.Aplicacion.Ciudades.Dto;
using Proveedores.Dominio.ObjetoValor;

namespace Proveedores.Aplicacion.Ciudades.Mapeadores
{
    public class CiudadesMapeador : Profile
    {
        public CiudadesMapeador()
        {
            CreateMap<Ciudad, CiudadDto>().ReverseMap();

        }
    }
}
