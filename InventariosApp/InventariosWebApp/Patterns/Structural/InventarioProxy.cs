using InventariosWebApp.Models;
using InventariosWebApp.Service.Implementacion;
using InventariosWebApp.Service.Interface;

namespace InventariosWebApp.Patterns.Structural
{
    /// <summary>
    /// Proporciona una implementación de proxy para el servicio de inventario, permitiendo la gestión de artículos a
    /// través de la interfaz IInventarioService.
    /// </summary>
    /// <remarks>Esta clase actúa como intermediario entre los consumidores y el servicio de inventario
    /// subyacente. Puede utilizarse para agregar lógica adicional, como almacenamiento en caché o registro, sin
    /// modificar el servicio original.</remarks>
    public class InventarioProxy : IInventarioService
    {
        private readonly InventarioService _service = new();

        public async Task<List<ArticuloDto>> ListarArticulos()
        {            
            return await _service.ListarArticulos();
        }
        public async Task InsertarNuevo(ArticuloIngresoDto dto)
        {            
            await _service.InsertarNuevo(dto);
        }

        
    }
}
