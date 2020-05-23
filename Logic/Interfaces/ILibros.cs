using Model;
using Model.AdmLibros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ILibros
    {
        Respuesta CrearLibro(Model.AdmLibros.Libros libro);
        Respuesta EditarLibro(Model.AdmLibros.Libros libro );
        List<Model.AdmLibros.Libros> BuscarLibros();
        Respuesta EliminarLibro(Model.AdmLibros.Libros libro);
    }
}
