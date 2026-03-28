using InventariosWebApp.Models;
using InventariosWebApp.Patterns;
using InventariosWebApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Validation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventariosWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {

        private readonly IInventarioService _service;

        public InventarioController(IInventarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene la lista completa de artículos almacenados en el inventario.
        /// </summary>
        /// <returns>Un resultado de acción que contiene la colección de artículos del inventario. El resultado tiene un código
        /// de estado HTTP 200 (OK) y el cuerpo incluye la lista de artículos. Si no hay artículos, la colección estará
        /// vacía.</returns>
        // GET: api/<InventarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.ListarArticulos());
        }
        /// <summary>
        /// Agrega un nuevo artículo al inventario utilizando los datos proporcionados.
        /// </summary>
        /// <param name="dto">Un objeto que contiene la información necesaria para crear el artículo, incluyendo nombre, precio, cantidad
        /// e identificador de categoría. No puede ser nulo.</param>
        /// <returns>Un resultado que indica si la operación se realizó correctamente.</returns>
        // POST api/<InventarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArticuloIngresoDto dto)
        {
            try
            {                
                await _service.InsertarNuevo(dto);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
