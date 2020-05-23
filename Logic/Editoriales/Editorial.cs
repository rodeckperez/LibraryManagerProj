using Logic.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Editoriales
{
    public class Editorial : IEditoriales
    {
        private static DataEntity.AppContext _context = new DataEntity.AppContext();
        public Respuesta agregarEditorial(Model.AdmLibros.Editorial editorial)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                _context.Editoriales.Add(editorial);
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

        public List<Model.AdmLibros.Editorial> ConsultarEditoriales()
        {
            return _context.Editoriales.ToList();
        }

        public Respuesta EditarEditorial(Model.AdmLibros.Editorial editorial)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var result = _context.Editoriales.SingleOrDefault(b => b.IdEditorial == editorial.IdEditorial);
                if (result != null)
                {
                    result.NombreEditorial = editorial.NombreEditorial;
                    result.NIT = editorial.NIT;
                    _context.Entry(result).CurrentValues.SetValues(editorial);
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

        public Respuesta EliminarEditorial(Model.AdmLibros.Editorial editorial)
        {
            throw new NotImplementedException();
        }
    }
}
