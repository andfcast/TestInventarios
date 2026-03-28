using InventariosWebApp.Models;

namespace InventariosWebApp.Patterns.Behavioral
{
    /// <summary>
    /// Observa los cambios en los artículos de inventario y realiza acciones de auditoría cuando se actualizan.
    /// Es el observador concreto que implementa la lógica de auditoría en respuesta a las notificaciones del Notificador. 
    /// Cuando se actualiza un artículo, este observador registra la información relevante para fines de auditoría.
    /// </summary>
    /// <remarks>Implementa la lógica de auditoría en sistemas que requieren
    /// registrar o monitorear modificaciones en los artículos del inventario. Puede integrarse con sistemas de registro
    /// o bases de datos de auditoría según sea necesario.</remarks>
    public class AuditoriaObserver : IInventarioObserver
    {
        public async Task Actualizar(ArticuloDto articulo)
        {
            // Simula la lógica de auditoría, como registrar cambios en un sistema de auditoría o base de datos.
            await Task.Run(() =>
            {
                Console.WriteLine($"[Auditoría] El artículo '{articulo.Nombre}' ha sido actualizado. Categoría: {articulo.Categoria}, Precio: {articulo.Precio}, Cantidad: {articulo.Cantidad}");
            });
        }
    }
}
