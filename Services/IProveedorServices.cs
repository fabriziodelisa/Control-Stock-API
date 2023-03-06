using Control_Stock.Models.DtoProveedor;

namespace Control_Stock.Services
{
    public interface IProveedorServices
    {
        public IEnumerable<ProveedorDTO> ObtenerTodosProveedores();
        public ProveedorDTO? ObtenerProveedor(int proveedorId);
        public ProveedorDTO CrearProveedor(CrearProveedorDTO crearProveedor);
        public void BorrarProveedor(int proveedorId);
        public void CambiarNombreProveedor(ModificarNombreProveedorDto proveedorDto, int proveedorId);
        public void CambiarDatosProveedor(ModificarDatosProveedorDTO datosNuevos, int proveedorId);
        public (bool, string) EsNombreValido(string nombre);
    }
}
