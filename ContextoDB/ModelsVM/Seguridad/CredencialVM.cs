using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDB.ModelsVM.Seguridad
{
    public class CredencialVM
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Token { get; set; }
        public List<int> RolId { get; set; }
        public List<MenuVM> Menus { get; set; }
        public List<PaginaVM> Paginas { get; set; }

    }
}
