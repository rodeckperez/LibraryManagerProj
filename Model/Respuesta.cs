using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Respuesta
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set;  }
    }

    public enum CodigosRespuesta {
        Success = 1, 
        Error = 2
    }
}
