using Model.Usuarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Web;
using System.Web.Http;

namespace LibraryAPI.Controllers
{
    public class UsuariosController : ApiController
    {

        private Logic.Usuarios.Usuarios objUsuarios = new Logic.Usuarios.Usuarios();

        [HttpGet]
        public string consultarUsuarios()
        {
            var lstUsuarios = objUsuarios.ConsultarUsuarios();
            return Newtonsoft.Json.JsonConvert.SerializeObject(lstUsuarios, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpGet]
        public string consultarTipoDocumento()
        {
            var lstTipoDoc = objUsuarios.ConsultarTipoDocumento();
            return Newtonsoft.Json.JsonConvert.SerializeObject(lstTipoDoc, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpPost]
        public string crearUsuario([FromBody] Usuarios usuario)
        {
            var respuesta = objUsuarios.CrearUsuario(usuario);
            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }


        [HttpPost]
        public string editarUsuario([FromBody] Usuarios usuario)
        {
            var respuesta = objUsuarios.EditarUsuario(usuario);
            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
