using InventariosWebApp.Models;

namespace InventariosWebApp.Service.Interface
{
    public interface IInventarioService
    {
        Task InsertarNuevo(ArticuloIngresoDto dto);
        Task<List<ArticuloDto>> ListarArticulos();
    }
}
