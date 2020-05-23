using Model;
using Model.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUsuarios
    {
        Respuesta CrearUsuario(Model.Usuarios.Usuarios usuario);
        Respuesta EditarUsuario(Model.Usuarios.Usuarios usuario);
        Respuesta EliminarUsuario(Model.Usuarios.Usuarios usuario);
        List<Model.Usuarios.Usuarios> ConsultarUsuarios();
        List<Model.Usuarios.TipoDocumento> ConsultarTipoDocumento();
    }
}
