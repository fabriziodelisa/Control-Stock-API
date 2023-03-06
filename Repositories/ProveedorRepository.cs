using Control_Stock.DbContexts;
using Control_Stock.Entities;
using Microsoft.EntityFrameworkCore;

namespace Control_Stock.Repositories
{
    public class ProveedorRepository : Repository, IProveedorRepository
    {
        public ProveedorRepository(StockContext stockContext) : base(stockContext)
        {

        }

        public Proveedor? ObtenerProveedor(int ProveedorId)
        {
            return _stockContext.Proveedores.FirstOrDefault(p => p.IdProveedor == ProveedorId);
        }

        public IEnumerable<Proveedor> ObtenerTodosProveedores()
        {
            return _stockContext.Proveedores.OrderBy(x => x.NombreProveedor).ToList();
        }

        public Proveedor CrearProveedor(Proveedor proveedor)
        {
            _stockContext.Proveedores.Add(proveedor);
            SaveChange();
            return proveedor;
        }

        public bool ExisteProveedorConMismoNombre(string nombreProveedor)
        {
            return _stockContext.Proveedores.Any(p => p.NombreProveedor.ToLower() == nombreProveedor.ToLower());
        }

        public void ModificarProveedor(Proveedor ProveedorActualizado)
        {
            _stockContext.Entry(ProveedorActualizado).State = EntityState.Modified;
            SaveChange();
        }

        public void BorrarProveedor(int ProveedorId)
        {
            var proveedor = _stockContext.Proveedores.Find(ProveedorId);
            if (proveedor != null)
                _stockContext.Proveedores.Remove(proveedor);
            SaveChange();
        }
    }
}
