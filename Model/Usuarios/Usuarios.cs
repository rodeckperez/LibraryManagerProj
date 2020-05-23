using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Usuarios
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual ICollection<Reservas.Reservas> ReservasUsuario { get; set; }
    }
}
