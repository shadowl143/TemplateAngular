
namespace ContextoDB.Models.Catalogos
{
    using ContextoDB.Models.Seguridad;

    public class RolPagina
    {
        public int RolId { get; set; }
        public int PaginaId { get; set; }
        public bool Activo { get; set; }

        public Rol Rol { get; set; }
        public Pagina Pagina { get; set; }

    }
}
