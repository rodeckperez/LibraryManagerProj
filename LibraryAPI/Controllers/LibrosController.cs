using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryAPI.Controllers
{
    public class LibrosController : ApiController
    {
        private Logic.Libros.Libros objLibros = new Logic.Libros.Libros();

        [HttpGet]
        public string dataLibros()
        {
            var dataDashboard = objLibros.datosLibro();
            return Newtonsoft.Json.JsonConvert.SerializeObject(dataDashboard, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpGet]
        public string consultarLibros()
        {
            var dataDashboard = objLibros.BuscarLibros();
            return Newtonsoft.Json.JsonConvert.SerializeObject(dataDashboard, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }


        [HttpPost]
        public string crearLibre([FromBody] Model.AdmLibros.Libros libro)
        {
            var respuesta = objLibros.CrearLibro(libro);
            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }


        [HttpPost]
        public string editarAutor([FromBody] Model.AdmLibros.Libros libro)
        {
            var respuesta = objLibros.EditarLibro(libro);
            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
