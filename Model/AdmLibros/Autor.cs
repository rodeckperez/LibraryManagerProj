using System;
using System.Collections.Generic;
using System.Text;

namespace Model.AdmLibros
{
    public class Autor
    {
        public int IdAutor { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public virtual ICollection<Libros> AutoresLibros {get; set;}
    }
}
