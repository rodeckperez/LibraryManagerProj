using Logic.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Autores
{
    public class Autor : IAutor
    {
        private static DataEntity.AppContext _context = new DataEntity.AppContext();
        public Respuesta AgregarAutor(Model.AdmLibros.Autor autorInfo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                _context.Autores.Add(autorInfo);
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

        public List<Model.AdmLibros.Autor> consultarAutores()
        {
            return _context.Autores.ToList();
        }

        public Respuesta EditarAutor(Model.AdmLibros.Autor autorInfo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var result = _context.Autores.SingleOrDefault(b => b.IdAutor == autorInfo.IdAutor);
                if (result != null)
                {
                    result.Nombres = autorInfo.Nombres;
                    result.Apellidos = autorInfo.Apellidos;
                    _context.Entry(result).CurrentValues.SetValues(autorInfo);
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

        public Respuesta EliminarAutor(Model.AdmLibros.Autor autorInfo)
        {
            throw new NotImplementedException();
        }
    }
}
