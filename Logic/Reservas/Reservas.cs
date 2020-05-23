using Logic.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logic.Utilidades;

namespace Logic.Reservas
{
    public class Reservas : IReservas
    {
        private static DataEntity.AppContext _context = new DataEntity.AppContext();
        public List<Model.Reservas.Reservas> ConsultarReservas()
        {
            return _context.Reserva.ToList();
        }

        public Respuesta CrearReserva(Model.Reservas.Reservas reserva)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                _context.Reserva.Add(reserva);
                _context.SaveChanges();
                respuesta.Codigo = (int)CodigosRespuesta.Success;
                respuesta.Descripcion = "Sucess";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Codigo = (int)CodigosRespuesta.Error;
                respuesta.Descripcion = e.Message;
                return respuesta;
            }
        }

        public dynamic DatosDashboard()
        {
            dynamic dataDashboard = new ExpandoObject();
            try
            {
                int idReservaActiva = (int) EstadosReserva.Activos;
                int idReservaMora = (int)EstadosReserva.ReservaMora;
                dataDashboard.CantidadReserva = _context.Reserva.Where(x => x.IdEstadoReserva == idReservaActiva).ToList().Count();
                dataDashboard.CantidadMora = _context.Reserva.Where(x => x.IdEstadoReserva == idReservaMora).ToList().Count();
                dataDashboard.CantidadUsuarios = _context.Usuario.Where(x => x.Estado).ToList().Count();
                dataDashboard.CantidadDisponibles = _context.Libro.Where(x => x.Disponible).ToList().Count();
                dataDashboard.Respuesta = "OK";
            }
            catch (Exception e)
            {
                dataDashboard.Respuesta = e.Message;
            }
            return dataDashboard;
        }

        public Respuesta EditarReserva(Model.Reservas.Reservas reserva)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var result = _context.Reserva.SingleOrDefault(b => b.IdReserva == reserva.IdReserva);
                if (result != null)
                {
                    result.FechaFinReserva = reserva.FechaFinReserva;
                    result.FechaReserva = reserva.FechaReserva;
                    _context.Entry(result).CurrentValues.SetValues(reserva);
                    _context.SaveChanges();
                }
                respuesta.Codigo = (int)CodigosRespuesta.Success;
                respuesta.Descripcion = "Sucess";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Codigo = (int)CodigosRespuesta.Error;
                respuesta.Descripcion = e.Message;
                return respuesta;
            }
        }

        public Respuesta EliminarReserva(Model.Reservas.Reservas reserva)
        {

            Respuesta respuesta = new Respuesta();
            try
            {
                _context.Reserva.Remove(reserva);
                _context.SaveChangesAsync();
                respuesta.Codigo = (int)CodigosRespuesta.Success;
                respuesta.Descripcion = "Sucess";
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Codigo = (int)CodigosRespuesta.Error;
                respuesta.Descripcion = e.Message;
                return respuesta;
            }
            return respuesta;
        }
    }
}
