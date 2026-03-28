using InventariosWebApp.Models;

namespace InventariosWebApp.Patterns.Behavioral
{
    /// <summary>
    /// Administra una colección de observadores de inventario y notifica a todos los observadores registrados cuando se
    /// produce un cambio en un artículo.
    /// </summary>
    /// <remarks>Aplicación del patrón Observerr en escenarios donde varios
    /// componentes necesitan reaccionar a cambios en el inventario. Los observadores deben implementar la interfaz
    /// IInventarioObserver para recibir notificaciones.</remarks>
    public class Notificador
    {
        private readonly List<IInventarioObserver> _observers = new();

        public void AgregarObserver(IInventarioObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notificar(ArticuloDto articulo) { 
            foreach(var observer in _observers)
            {
                observer.Actualizar(articulo);
            }
        }

    }
}
