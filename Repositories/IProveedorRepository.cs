using Control_Stock.Entities;

namespace Control_Stock.Repositories
{
    public interface IProveedorRepository
    {
        public Proveedor? ObtenerProveedor(int ProveedorId);
        public IEnumerable<Proveedor> ObtenerTodosProveedores();
        public Proveedor CrearProveedor(Proveedor proveedor);
        public bool ExisteProveedorConMismoNombre(string nombreProveedor);
        public void BorrarProveedor(int ProveedorId);
        public void ModificarProveedor(Proveedor ProveedorActualizado);
    }
}
