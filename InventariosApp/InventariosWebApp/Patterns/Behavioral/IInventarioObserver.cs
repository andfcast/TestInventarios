using InventariosWebApp.Models;

namespace InventariosWebApp.Patterns.Behavioral
{
    public interface IInventarioObserver
    {
        Task Actualizar(ArticuloDto articulo);
    }
}
