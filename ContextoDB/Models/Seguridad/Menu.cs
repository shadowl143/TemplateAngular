namespace ContextoDB.Models.Seguridad
{
    using System.ComponentModel.DataAnnotations;

    public class Menu
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Icono { get; set; }
        [MaxLength(20)]
        public string Clave { get; set; }
        [MaxLength(20)]
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public List<Pagina> Pagina { get; set; }
    }
}
