using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Reservas
{
    public class EstadoReserva
    {
        public int IdEstado { get; set; }
        public string DescripcionEstado { get; set; }
        public virtual ICollection<Reservas> EstadoReservas { get; set; }
    }
}
