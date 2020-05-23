using Model.AdmLibros;
using Model.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Reservas
{
    public class Reservas
    {
        public int IdReserva { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaFinReserva { get; set; }
        public int IdUsuario { get; set; }
        public int IdLibro { get; set; }
        public int IdEstadoReserva { get; set; }
        public virtual Usuarios.Usuarios UsuarioReserva { get; set; }
        public virtual EstadoReserva ReservasEstado { get; set; }
        public virtual Libros LibroReservado { get; set; }
    }
}
