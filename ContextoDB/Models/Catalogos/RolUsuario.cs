
namespace ContextoDB.Models.Catalogos
{
    public  class RolUsuario
    {
        public int RolId { get; set; }
        public int UsuarioId { get; set; }
        public bool Activo { get; set; }
        public Rol Rol { get; set; }
        public Usuario Usuario { get; set; }
    }
}
