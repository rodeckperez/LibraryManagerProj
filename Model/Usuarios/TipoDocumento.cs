using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Usuarios
{
    public class TipoDocumento
    {
        public int Id { get; set; }
        public string Tipo { get; set; } 
        public virtual ICollection<Usuarios> TDocumentoUsuarios { get; set; }
    }
}
