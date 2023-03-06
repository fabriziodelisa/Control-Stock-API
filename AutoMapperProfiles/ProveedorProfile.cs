using AutoMapper;
using Control_Stock.Entities;
using Control_Stock.Models.DtoProveedor;

namespace Control_Stock.AutoMapperProfiles
{
    public class ProveedorProfile : Profile
    {
        public ProveedorProfile()
        {
            CreateMap<Proveedor, ProveedorDTO>().ReverseMap();
            CreateMap<CrearProveedorDTO, Proveedor>();
            CreateMap<ModificarNombreProveedorDto, Proveedor>();
            CreateMap<ModificarDatosProveedorDTO, Proveedor>();
        }
    }
}
