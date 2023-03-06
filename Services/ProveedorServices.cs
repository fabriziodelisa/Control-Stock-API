using AutoMapper;
using Control_Stock.AutoMapperProfiles;
using Control_Stock.Entities;
using Control_Stock.Models.DtoProveedor;
using Control_Stock.Repositories;

namespace Control_Stock.Services
{
    public class ProveedorServices : IProveedorServices
    {
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IMapper _mapper;

        public ProveedorServices(IMapper mapper, IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProveedorDTO> ObtenerTodosProveedores()
        {
            var proveedores = _proveedorRepository.ObtenerTodosProveedores();
            return _mapper.Map<IEnumerable<ProveedorDTO>>(proveedores);
        }

        public ProveedorDTO ObtenerProveedor(int proveedorId)
        {
            var proveedor = _proveedorRepository.ObtenerProveedor(proveedorId);
            return _mapper.Map<ProveedorDTO>(proveedor);
        }

        public ProveedorDTO CrearProveedor(CrearProveedorDTO crearProveedor)
        {
            var nuevoProveedor = _mapper.Map<Proveedor>(crearProveedor);

            var proveedorDevuelto = _proveedorRepository.CrearProveedor(nuevoProveedor);

            return _mapper.Map<ProveedorDTO>(proveedorDevuelto);
        }

        public void CambiarNombreProveedor(ModificarNombreProveedorDto nombreNuevo, int proveedorId)
        {
            var ProveedorActualizar = _proveedorRepository.ObtenerProveedor(proveedorId);

            _mapper.Map(nombreNuevo, ProveedorActualizar);

            _proveedorRepository.ModificarProveedor(ProveedorActualizar);
        }

        public void CambiarDatosProveedor(ModificarDatosProveedorDTO datosNuevos, int proveedorId)
        {
            var ProveedorActualizar = _proveedorRepository.ObtenerProveedor(proveedorId);

            _mapper.Map(datosNuevos, ProveedorActualizar);

            _proveedorRepository.ModificarProveedor(ProveedorActualizar);
        }

        public void BorrarProveedor(int ProveedorId)
        {
            _proveedorRepository.BorrarProveedor(ProveedorId);
        }

        public (bool, string) EsNombreValido(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return (false, "Es necesario un nombre de proveedor.");
            }

            if (nombre.Length > 35)
            {
                return (false, "El nombre del proveedor debe tener como máximo 35 caracteres.");
            }
            if (_proveedorRepository.ExisteProveedorConMismoNombre(nombre))
            {
                return (false, $"Ya existe un proveedor con el nombre '{nombre}'.");
            }

            return (true, string.Empty);
        }
    }
}
