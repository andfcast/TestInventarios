using InventariosWebApp.Models;
using InventariosWebApp.Patterns;
using InventariosWebApp.Service.Interface;

namespace InventariosWebApp.Service.Implementacion
{
    public class InventarioService : IInventarioService
    {
        /// <summary>
        /// Obtiene una lista de todos los artículos disponibles en el inventario.
        /// </summary>
        /// <returns>Una lista de objetos ArticuloDto que representan los artículos actuales en el inventario. La lista estará
        /// vacía si no hay artículos disponibles.</returns>
        public async Task<List<ArticuloDto>> ListarArticulos() {
            return InventarioStorage.Instance.lstArticulos;
        }

        /// <summary>
        /// Inserta un nuevo artículo en el inventario utilizando los datos proporcionados en el objeto ArticuloIngresoDto.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task InsertarNuevo(ArticuloIngresoDto dto) {
            var factory = await ObtenerFactory(dto.IdCategoria);
            var objArticulo = new ArticuloBuilder(factory.CrearArticulo())
                .SetNombre(dto.Nombre)
                .SetPrecio(dto.Precio)
                .SetCantidad(dto.Cantidad)
                .Build();

            InventarioStorage.Instance.lstArticulos.Add(objArticulo);
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
