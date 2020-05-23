using Logic.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Libros
{
    public class Libros : ILibros
    {
        private static DataEntity.AppContext _context = new DataEntity.AppContext();

        public List<Model.AdmLibros.Libros> BuscarLibros()
        {
            return _context.Libro.ToList();
        }

        public Respuesta CrearLibro(Model.AdmLibros.Libros libro)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();
                respuesta.Codigo = (int)CodigosRespuesta.Success;
                respuesta.Descripcion = "Sucess";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Codigo = (int)CodigosRespuesta.Error;
                respuesta.Descripcion = e.Message;
                return respuesta;
            }
        }

        public Respuesta EditarLibro(Model.AdmLibros.Libros libro)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var result = _context.Libro.SingleOrDefault(b => b.IdLibro == libro.IdLibro);
                if (result != null)
                {
                    result.Nombre = libro.Nombre;
                    result.IdAutor = libro.IdAutor;
                    result.IdCategoria = libro.IdCategoria;
                    result.Sinapsis = libro.Sinapsis;
                    result.Idioma = libro.Idioma;
                    result.Disponible = libro.Disponible;
                    _context.Entry(result).CurrentValues.SetValues(libro);
                    _context.SaveChanges();
                }
                respuesta.Codigo = (int)CodigosRespuesta.Success;
                respuesta.Descripcion = "Sucess";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Codigo = (int)CodigosRespuesta.Error;
                respuesta.Descripcion = e.Message;
                return respuesta;
            }
        }

        public Respuesta EliminarLibro(Model.AdmLibros.Libros libro)
        {
            throw new NotImplementedException();
        }

        public dynamic datosLibro() {
            dynamic dataDashboard = new ExpandoObject();
            try
            {
                dataDashboard.Autores = _context.Autores.ToList();
                dataDashboard.Categorias = _context.Categorias.ToList();
                dataDashboard.Editorial = _context.Editoriales.ToList();
                dataDashboard.Respuesta = "OK";
            }
            catch (Exception e)
            {
                dataDashboard.Respuesta = e.Message;
            }
            return dataDashboard;
        }
    }
}
