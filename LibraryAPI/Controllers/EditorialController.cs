using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryAPI.Controllers
{
    public class EditorialController : ApiController
    {
        private Logic.Editoriales.Editorial objEditorial = new Logic.Editoriales.Editorial();

        [HttpGet]
        public string consultarEditoriales()
        {
            var lstUsuarios = objEditorial.ConsultarEditoriales();
            return Newtonsoft.Json.JsonConvert.SerializeObject(lstUsuarios, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpPost]
        public string crearEditorial([FromBody] Model.AdmLibros.Editorial editorial)
        {
            var respuesta = objEditorial.agregarEditorial(editorial);
            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }


        [HttpPost]
        public string editarEditorial([FromBody]  Model.AdmLibros.Editorial editorial)
        {
            var respuesta = objEditorial.EditarEditorial(editorial);
            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
