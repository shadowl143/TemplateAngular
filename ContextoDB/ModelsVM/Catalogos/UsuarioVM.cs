
namespace ContextoDB.ModelsVM.Catalogos
{
    public class UsuarioVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string? NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public string? Password { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
        public bool CambiarPass { get; set; }
    }
}
