using System;
using System.Collections.Generic;
using System.Text;

namespace Model.AdmLibros
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Libros> CategoriaLibro { get; set; }
    }
}
