using Model;
using Model.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IReservas
    {
        Respuesta CrearReserva(Model.Reservas.Reservas reserva);
        Respuesta EditarReserva(Model.Reservas.Reservas reserva);
        Respuesta EliminarReserva(Model.Reservas.Reservas reserva);
        List<Model.Reservas.Reservas> ConsultarReservas();
        dynamic DatosDashboard(); 
    }
}
