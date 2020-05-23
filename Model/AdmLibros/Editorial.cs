using System;
using System.Collections.Generic;
using System.Text;

namespace Model.AdmLibros
{
    public class Editorial
    {
        public int IdEditorial { get; set; }
        public string NIT { get; set; }
        public string NombreEditorial { get; set; }
        public virtual ICollection<Libros> EditorialLibros { get; set; }
    }
}
