using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryAPI.Controllers
{
    public class AutorController : ApiController
    {

        private Logic.Autores.Autor objAutores = new Logic.Autores.Autor();

        [HttpGet]
        public string consultarAutores()
        {
            var lstUsuarios = objAutores.consultarAutores();
            return Newtonsoft.Json.JsonConvert.SerializeObject(lstUsuarios, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

       [HttpPost]
        public string crearAutor([FromBody] Model.AdmLibros.Autor autor)
        {
            var respuesta = objAutores.AgregarAutor(autor);
            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }


        [HttpPost]
        public string editarAutor([FromBody] Model.AdmLibros.Autor usuario)
        {
            var respuesta = objAutores.EditarAutor(usuario);
            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
