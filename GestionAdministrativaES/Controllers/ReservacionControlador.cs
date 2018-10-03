using GestionAdministrativaES.Models;
using GestionAdministrativaES.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Controllers
{
    public class ReservacionControlador
    {
        ReservacionDAO reservacionDAO = new ReservacionDAO();

        public void insertarReservacion(string idUsuario, string idSalon, string idOperador, string estado, string carta, string periodo)
        {
            try
            {
                if (carta != null)
                {
                    if (carta != "")
                    {
                        reservacionDAO.insertarReservacion(Convert.ToInt32(idUsuario), Convert.ToInt32(idSalon), Convert.ToInt32(idOperador), Convert.ToInt32(estado), carta, periodo);
                        HttpContext.Current.Response.Redirect("../Reservacion/AdministrarReservaciones.aspx", true);
                    }
                    else
                    {
                        HttpContext.Current.Response.Write("<script>window.alert('No se permiten espacios en blanco!');</script>");
                    }
                }
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al modificar reservacion.');</script>");
            }
        }

        public Reservacion buscarReservacion(string idReservacion) {
            Reservacion reservacion = reservacionDAO.buscarReservacion(Convert.ToInt32(idReservacion));
            if (reservacion != null)
            {
                return reservacion;
            }
            else
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al obtener reservacion.');</script>");
                return null;
            }
        }

        public void modificarReservacion(string idReservacion, string idUsuario, string idSalon, string idOperador, string estado, string carta, string periodo)
        {
            try
            {
                if (carta != null)
                {
                    if (carta != "")
                    {
                        reservacionDAO.modificarReservacion(Convert.ToInt32(idReservacion), Convert.ToInt32(idUsuario), Convert.ToInt32(idSalon), Convert.ToInt32(idOperador), Convert.ToInt32(estado), carta, periodo);
                        HttpContext.Current.Response.Redirect("../Reservacion/AdministrarReservaciones.aspx", true);
                    }
                    else
                    {
                        HttpContext.Current.Response.Write("<script>window.alert('No se permiten espacios en blanco!');</script>");
                    }
                }
            }
            catch(Exception e)
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al modificar reservacion.');</script>");
            }
        }

        public void eliminarReservacion(string idReservacion)
        {
            try
            {
                reservacionDAO.eliminarReservacion(Convert.ToInt32(idReservacion));
                HttpContext.Current.Response.Redirect("../Reservacion/AdministrarReservaciones.aspx", true);
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al eliminar reservacion.');</script>");
            }
        }
    }
}