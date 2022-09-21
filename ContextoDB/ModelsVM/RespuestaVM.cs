using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDB.ModelsVM
{
    public class RespuestaVM<T>
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public string MensajeError { get; set; }
        public T Model { get; set; }
    }
}
