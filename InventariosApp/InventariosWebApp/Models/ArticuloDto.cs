namespace InventariosWebApp.Models
{
    /// <summary>
    /// Representa una entidad base de transferencia de datos para un artículo, que incluye información común como
    /// nombre, precio, categoría y cantidad.
    /// </summary>
    /// <remarks>Esta clase se utiliza como base para objetos de transferencia de datos (DTO) relacionados con
    /// artículos en aplicaciones de inventario, ventas o gestión de productos. Puede ser heredada para agregar
    /// propiedades o comportamientos adicionales específicos de cada tipo de artículo.</remarks>
    public abstract class ArticuloDto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
    }

    public class ProdTecnologiaDto : ArticuloDto { }
    public class ProdHogarDto : ArticuloDto { }
    public class ProdAlimentosDto : ArticuloDto { }
    public class ProdRopaDto : ArticuloDto { }

    //Aplicación del patrón Factory Method para crear instancias de ArticuloDto según la categoría
    public abstract class ArticuloDtoFactory
    {
        public abstract ArticuloDto CrearArticulo();
    }

    /// <summary>
    /// Proporciona un factory especializado para crear instancias de artículos de categoría 'Tecnología'.
    /// </summary>
    /// <remarks>Utilice esta clase para generar objetos de categoría 'Tecnología' de manera consistente dentro del
    /// sistema. Hereda de ArticuloDtoFactory y sobrescribe el método de creación para establecer la categoría
    /// correspondiente.</remarks>
    public class ProdTecnologiaFactory : ArticuloDtoFactory
    {
        public override ArticuloDto CrearArticulo()
        {
            return new ProdTecnologiaDto
            {
                Categoria = "Tecnología"
            };
        }
    }
    /// <summary>
    /// Proporciona un factory especializado para crear instancias de artículos de categoría 'Hogar'.
    /// </summary>
    /// <remarks>Utilice esta clase para generar objetos de categoría 'Hogar' de manera consistente dentro del
    /// sistema. Hereda de ArticuloDtoFactory y sobrescribe el método de creación para establecer la categoría
    /// correspondiente.</remarks>
    public class HogarFactory : ArticuloDtoFactory
    {
        public override ArticuloDto CrearArticulo()
        {
            return new ProdHogarDto
            {
                Categoria = "Hogar"
            };
        }
    }
    /// <summary>
    /// Proporciona un factory especializado para crear instancias de artículos de categoría 'Alimentos'.
    /// </summary>
    /// <remarks>Utilice esta clase para generar objetos de categoría 'Alimentos' de manera consistente dentro del
    /// sistema. Hereda de ArticuloDtoFactory y sobrescribe el método de creación para establecer la categoría
    /// correspondiente.</remarks>
    public class AlimentosFactory : ArticuloDtoFactory
    {
        public override ArticuloDto CrearArticulo()
        {
            return new ProdAlimentosDto
            {
                Categoria = "Alimentos"
            };
        }
    }
    /// <summary>
    /// Proporciona un factory especializado para crear instancias de artículos de categoría 'Ropa'.
    /// </summary>
    /// <remarks>Utilice esta clase para generar objetos de categoría 'Ropa' de manera consistente dentro del
    /// sistema. Hereda de ArticuloDtoFactory y sobrescribe el método de creación para establecer la categoría
    /// correspondiente.</remarks>
    public class RopaFactory : ArticuloDtoFactory
    {
        public override ArticuloDto CrearArticulo()
        {
            return new ProdRopaDto
            {
                Categoria = "Ropa"
            };
        }
    }
}
