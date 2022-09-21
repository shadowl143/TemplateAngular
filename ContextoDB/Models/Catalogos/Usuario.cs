namespace ContextoDB.Models.Catalogos
{
    using System.ComponentModel.DataAnnotations;

    public class Usuario
    {

        public int Id { get; set; }// identificador unico
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Apellido { get; set; }
        [MaxLength(100)]
        public string NombreUsuario { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
    }
}
