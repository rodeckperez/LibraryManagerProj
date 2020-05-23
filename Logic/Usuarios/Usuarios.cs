using Logic.Interfaces;
using Model;
using Model.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Usuarios
{
    public class Usuarios : IUsuarios
    {
        private static DataEntity.AppContext _context = new DataEntity.AppContext();

        public List<TipoDocumento> ConsultarTipoDocumento()
        {
            return _context.TDocumento.ToList();
        }

        public List<Model.Usuarios.Usuarios> ConsultarUsuarios()
        {
            return _context.Usuario.ToList();
        }

        public Respuesta CrearUsuario(Model.Usuarios.Usuarios usuario)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                _context.Usuario.Add(usuario);
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

        public Respuesta EditarUsuario(Model.Usuarios.Usuarios usuario)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var result = _context.Usuario.SingleOrDefault(b => b.IdUsuario == usuario.IdUsuario);
                if (result != null)
                {
                    result.Nombres = usuario.Nombres;
                    result.Apellidos = usuario.Apellidos;
                    result.Telefono = usuario.Telefono;
                    result.IdTipoDocumento = usuario.IdTipoDocumento;
                    result.Direccion = usuario.Direccion;
                    result.NumeroIdentificacion = usuario.NumeroIdentificacion;
                    _context.Entry(result).CurrentValues.SetValues(usuario);
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

        public Respuesta EliminarUsuario(Model.Usuarios.Usuarios usuario)
        {
            throw new NotImplementedException();
        }
    }
}
