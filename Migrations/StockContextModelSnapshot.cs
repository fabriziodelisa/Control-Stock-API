﻿// <auto-generated />
using Control_Stock.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControlStock.Migrations
{
    [DbContext(typeof(StockContext))]
    partial class StockContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Control_Stock.Entities.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreProveedor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlLogo")
                        .HasColumnType("TEXT");

                    b.HasKey("IdProveedor");

                    b.ToTable("Proveedores");

                    b.HasData(
                        new
                        {
                            IdProveedor = 1,
                            Descripcion = "Empresa dedicada al acero inoxidable",
                            Direccion = "Pellegrini 1800",
                            NombreProveedor = "Famiq",
                            Telefono = "4444444",
                            UrlLogo = "www.xxxxxxxxxxx.com"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
