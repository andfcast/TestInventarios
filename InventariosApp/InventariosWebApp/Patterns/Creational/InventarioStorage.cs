using InventariosWebApp.Models;
using InventariosWebApp.Patterns.Behavioral;

namespace InventariosWebApp.Patterns.Creational
{
    /// <summary>
    /// Proporciona un almacenamiento centralizado para los artículos del inventario utilizando el patrón singleton.
    /// </summary>
    /// <remarks>Esta clase garantiza que solo exista una instancia compartida de almacenamiento de inventario
    /// durante la ejecución de la aplicación. Utilice la propiedad Instance para acceder a la instancia global. No es
    /// seguro para subprocesos.</remarks>
    public class InventarioStorage
    {
        private static InventarioStorage _objInstance;
        public List<ArticuloDto> lstArticulos { get; } = new List<ArticuloDto>();

        public Notificador notificador { get; } = new();

        private InventarioStorage() {
            notificador.AgregarObserver(new AuditoriaObserver());
        }

        public static InventarioStorage Instance
        {
            get
            {
                if (_objInstance == null)
                {
                    _objInstance = new InventarioStorage();
                }
                return _objInstance;
            }
        }

        public void AgregarArticulo(ArticuloDto articulo)
        {
            lstArticulos.Add(articulo);
            notificador.Notificar(articulo);
        }
    }
}
