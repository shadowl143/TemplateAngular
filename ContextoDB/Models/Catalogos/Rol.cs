
namespace ContextoDB.Models.Catalogos
{
    using System.ComponentModel.DataAnnotations;


    public class Rol
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Clave { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public List<RolUsuario> RolUsuario { get; set; }
        public List<RolPagina> RolPagina { get; set; }

    }
}
