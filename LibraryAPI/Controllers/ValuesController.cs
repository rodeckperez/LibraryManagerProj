using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryAPI.Controllers
{
    public class ValuesController : ApiController
    {

         private Logic.Reservas.Reservas objReservas = new Logic.Reservas.Reservas();

        [HttpGet]
        public string dataDashboard()
        {
            var dataDashboard = objReservas.DatosDashboard();
            return Newtonsoft.Json.JsonConvert.SerializeObject(dataDashboard);
        }
        [HttpPost]
        public string crearReserva([FromBody] Model.Reservas.Reservas reservas)
        {
            var respuesta = objReservas.CrearReserva(reservas);
            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }


        [HttpPost]
        public string editarAutor([FromBody] Model.Reservas.Reservas reservas)
        {
            var respuesta = objReservas.EditarReserva(reservas);
            return Newtonsoft.Json.JsonConvert.SerializeObject(respuesta, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
