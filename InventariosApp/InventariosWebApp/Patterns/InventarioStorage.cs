using InventariosWebApp.Models;

namespace InventariosWebApp.Patterns
{
    public class InventarioStorage
    {
        private static InventarioStorage _objInstance;
        public List<ArticuloDto> lstArticulos { get; } = new List<ArticuloDto>();

        private InventarioStorage() { }

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
    }
}
