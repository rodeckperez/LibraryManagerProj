using Logic.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Categorias
{
    public class Categoria : ICategorias
    {
        private static DataEntity.AppContext _context = new DataEntity.AppContext();
        public Respuesta AgregarCategoria(Model.AdmLibros.Categoria categoria)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                _context.Categorias.Add(categoria);
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

        public List<Model.AdmLibros.Categoria> consultarCategorias()
        {
            return _context.Categorias.ToList();
        }

        public Respuesta EditarCategoria(Model.AdmLibros.Categoria categoria)
        {

            Respuesta respuesta = new Respuesta();
            try
            {
                var result = _context.Categorias.SingleOrDefault(b => b.IdCategoria == categoria.IdCategoria);
                if (result != null)
                {
                    result.Nombre = categoria.Nombre;
                    result.Descripcion = categoria.Descripcion;
                    _context.Entry(result).CurrentValues.SetValues(categoria);
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

        public Respuesta EliminarCategoria(Model.AdmLibros.Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
