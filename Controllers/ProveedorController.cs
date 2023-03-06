using AutoMapper;
using Control_Stock.Entities;
using Control_Stock.Models.DtoProveedor;
using Control_Stock.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Control_Stock.Controllers
{

    [Route("api/proveedores")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorServices _proveedorServices;
        private readonly IMapper _mapper;
        public ProveedorController(IProveedorServices proveedorServices, IMapper mapper)
        {
            _proveedorServices = proveedorServices;
            _mapper = mapper;
        }

        [HttpGet("obtenerTodosLosProveedores")]
        public ActionResult ObtenerTodosProveedores()
        {
            var proveedores = _proveedorServices.ObtenerTodosProveedores();
            return Ok(proveedores);
        }

        [HttpGet("obtenerProveedor/{id}")]
        public ActionResult ObtenerProveedor(int id)

        {
            var proveedor = _proveedorServices.ObtenerProveedor(id);
            if (proveedor == null)
                return NotFound("No se encontró un proveedor con el id asociado");
            return Ok(proveedor);
        }

        [HttpPost("CrearProveedor")]
        public ActionResult<ProveedorDTO> CrearProveedor(CrearProveedorDTO proveedor)
        {
            var (esValido, errorMensaje) = _proveedorServices.EsNombreValido(proveedor.NombreProveedor);

            if (!esValido) 
                return BadRequest(errorMensaje);

            var proveedorCreado = _proveedorServices.CrearProveedor(proveedor);

            return Ok(new
            {
                mensaje = "El proveedor ha sido creado exitosamente.",
                proveedor = proveedorCreado
            });
           //return CreatedAtRoute("obtenerProveedor", new{id = proveedorCreado.IdProveedor}, proveedorCreado);
        }

        [HttpPut("ModificarNombreProveedor")]
        public ActionResult ModificarNombreProveedor(ModificarNombreProveedorDto nombreNuevo, int proveedorId)
        {
            if (_proveedorServices.ObtenerProveedor(proveedorId) is null)
            {
                return NotFound("No existe un proveedor con el id Asociado");
            }

            var (esValido, errorMensaje) = _proveedorServices.EsNombreValido(nombreNuevo.NombreProveedor);

            if (!esValido)
                return BadRequest(errorMensaje);

            _proveedorServices.CambiarNombreProveedor(nombreNuevo, proveedorId);

            var proveedorActualizado = _proveedorServices.ObtenerProveedor(proveedorId);
            var proveedorActualizadoDTO = _mapper.Map<ProveedorDTO>(proveedorActualizado);

            return Ok(new {
            mensaje = "El nombre del proveedor ha sido actualizado exitosamente.",
            proveedor = proveedorActualizadoDTO
            });
        }

        [HttpPut("ModificarDatosProveedor")]
        public ActionResult ModificarDatosProveedor(ModificarDatosProveedorDTO datosNuevos, int proveedorId)
        {
            if (_proveedorServices.ObtenerProveedor(proveedorId) is null)
            {
                return NotFound("No existe un proveedor con el id Asociado");
            }

            _proveedorServices.CambiarDatosProveedor(datosNuevos, proveedorId);

            var proveedorActualizado = _proveedorServices.ObtenerProveedor(proveedorId);
            var proveedorActualizadoDTO = _mapper.Map<ProveedorDTO>(proveedorActualizado);

            return Ok(new
            {
                mensaje = "Los datos del proveedor han sido actualizado exitosamente.",
                proveedor = proveedorActualizadoDTO
            });
        }

        [HttpDelete("borrarProveedor/{id}")]
        public ActionResult BorrarProveedor(int id)
        {
            if (_proveedorServices.ObtenerProveedor(id) is null)
            {
                return NotFound("No existe un proveedor con el id Asociado");
            }
            _proveedorServices.BorrarProveedor(id);

            return Ok("El proveedor fue eliminado exitosamente.");
        }
    }
}
