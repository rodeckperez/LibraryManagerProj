using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryAPI.Controllers
{
    public class CategoriaController : ApiController
    {
        private Logic.Categorias.Categoria objCategorias = new Logic.Categorias.Categoria();

        [HttpGet]
        public string consultaCategorias()
        {
            var lstUsuarios = objCategorias.consultarCategorias();
            return Newtonsoft.Json.JsonConvert.SerializeObject(lstUsuarios, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [HttpPost]
        public string crearCategoria([FromBody] Model.AdmLibros.Categoria categoria)
        {
            var respuesta = objCategorias.AgregarCategoria(categoria);
            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }


        [HttpPost]
        public string editarCategoria([FromBody] Model.AdmLibros.Categoria categoria)
        {
            var respuesta = objCategorias.EditarCategoria(categoria);
            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
