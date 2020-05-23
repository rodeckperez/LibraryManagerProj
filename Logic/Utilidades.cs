using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Utilidades
    {
        public enum EstadosReserva {
            Activos = 1, 
            ActivosConTiempo = 2, 
            ReservaMora = 3, 
            Finalizado = 4
        }
    }
}
