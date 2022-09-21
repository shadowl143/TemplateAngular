
namespace ContextoDB.ModelsVM.Seguridad
{
    public class PaginaVM
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Icon { get; set; }
        public string Nombre { get; set; }
        public string MenuNombre { get; set; }
        public int MenuId { get; set; }
        public bool Activo { get; set; }
    }
}
