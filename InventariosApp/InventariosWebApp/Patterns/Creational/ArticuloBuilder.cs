using InventariosWebApp.Models;

namespace InventariosWebApp.Patterns.Creational
{
    /// <summary>
    /// Implementación del patrón Builder para construir objetos ArticuloDto complejos de manera fluida y flexible.
    /// </summary>
    public class ArticuloBuilder
    {
        private ArticuloDto _objArticulo;
        /// <summary>
        /// Initializa una nueva instancia de la clase ArticuloBuilder con los datos especificados del artículo.
        /// </summary>
        /// <param name="articulo">El objeto ArticuloDto que contiene los datos del artículo que se utilizarán para construir la instancia.</param>
        public ArticuloBuilder(ArticuloDto articulo)
        {
            _objArticulo = articulo;
        }
        /// <summary>
        /// Establece el nombre del artículo en construcción.
        /// </summary>
        /// <param name="nombre">El nuevo nombre que se asignará al artículo. No puede ser null.</param>
        /// <returns>La instancia actual de ArticuloBuilder para permitir la invocación encadenada de métodos.</returns>
        public ArticuloBuilder SetNombre(string nombre)
        {
            _objArticulo.Nombre = nombre;
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="precio"></param>
        /// <returns></returns>
        public ArticuloBuilder SetPrecio(double precio)
        {
            _objArticulo.Precio = precio;
            return this;
        }
        /// <summary>
        /// Establece la cantidad del artículo asociado al generador.
        /// </summary>
        /// <param name="cantidad">La cantidad que se asignará al artículo. Debe ser un valor entero igual o mayor que cero.</param>
        /// <returns>La instancia actual de <see cref="ArticuloBuilder"/> para permitir la invocación encadenada de métodos.</returns>
        public ArticuloBuilder SetCantidad(int cantidad)
        {
            _objArticulo.Cantidad = cantidad;
            return this;
        }
        /// <summary>
        /// Crea y devuelve una nueva instancia de ArticuloDto basada en la configuración actual del generador.
        /// </summary>
        /// <returns>Una instancia de ArticuloDto que representa el resultado de la configuración actual. Nunca es null.</returns>
        public ArticuloDto Build()
        {
            return _objArticulo;
        }
    }
}
