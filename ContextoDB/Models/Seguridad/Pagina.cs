using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDB.Models.Seguridad
{
    public class Pagina
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Clave { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        public int MenuId { get; set; }
        public bool Activo { get; set; }

        public Menu Menu { get; set; }
    }
}
