namespace InventariosWebApp.Models
{
    public class ArticuloIngresoDto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int IdCategoria { get; set; }
        public int Cantidad { get; set; }
    }
}
