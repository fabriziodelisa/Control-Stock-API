using Control_Stock.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Control_Stock.DbContexts

{
    public class StockContext: DbContext
    {
        //public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        //public DbSet<Precio> Precios { get; set; }

        public StockContext(DbContextOptions<StockContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedor>().HasData(
                new Proveedor
                {
                    IdProveedor = 1,
                    NombreProveedor = "Famiq",
                    Telefono = "4444444",
                    Direccion = "Pellegrini 1800",
                    Descripcion = "Empresa dedicada al acero inoxidable",
                    UrlLogo = "www.xxxxxxxxxxx.com",
                }
            );

            base.OnModelCreating(modelBuilder);

        }
    }
}
