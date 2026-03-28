using InventariosWebApp.Models;
using InventariosWebApp.Patterns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Validation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventariosWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
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
            return Ok(InventarioStorage.Instance.lstArticulos);
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
                var factory = await ObtenerFactory(dto.IdCategoria);
                var objArticulo = new ArticuloBuilder(factory.CrearArticulo())
                    .SetNombre(dto.Nombre)
                    .SetPrecio(dto.Precio)
                    .SetCantidad(dto.Cantidad)
                    .Build();

                InventarioStorage.Instance.lstArticulos.Add(objArticulo);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Obtiene una instancia de la fábrica de artículos correspondiente a la categoría especificada.
        /// </summary>
        /// <param name="idCategoria">El identificador de la categoría para la que se solicita la fábrica. Debe ser un valor válido que represente
        /// una categoría soportada.</param>
        /// <returns>Una instancia de la fábrica de artículos asociada a la categoría indicada.</returns>
        /// <exception cref="ArgumentException">Se produce si <paramref name="idCategoria"/> no corresponde a una categoría válida.</exception>
        private async Task<ArticuloDtoFactory> ObtenerFactory(int idCategoria)
        {
            return idCategoria switch
            {
                1 => new ProdTecnologiaFactory(),
                2 => new HogarFactory(),
                3 => new AlimentosFactory(),
                4 => new RopaFactory(),
                _ => throw new ArgumentException("Categoría no válida")
            };
        }
    }
}
