using System;
using System.Collections.Generic;
using System.Text;

namespace Model.AdmLibros
{
    public class Libros
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public int IdAutor { get; set; }
        public int IdCategoria { get; set; }
        public int IdEditorial { get; set; }
        public string Sinapsis { get; set; }
        public string Idioma { get; set; }
        public bool Disponible { get; set; }
        public virtual Autor AutorLibro { get; set; }
        public virtual Categoria CategoriaLibro { get; set; }
        public virtual Editorial EditorialLibro { get; set; }
        public virtual ICollection<Reservas.Reservas> ReservasLibro { get; set; }
    }
}
