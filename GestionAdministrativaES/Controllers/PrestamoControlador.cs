using GestionAdministrativaES.Models;
using GestionAdministrativaES.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Controllers
{
    public class PrestamoControlador
    {
        PrestamoDAO prestamoDAO = new PrestamoDAO();

        public void insertarPrestamo(string idInsumo, string idUsuario, string idOperador, string fecha)
        {
            try
            {
                if (fecha != "")
                {
                    prestamoDAO.insertarPrestamo(Convert.ToInt32(idUsuario), Convert.ToInt32(idInsumo), Convert.ToInt32(idOperador), fecha, 0);
                    HttpContext.Current.Response.Redirect("AdministrarPrestamos.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('No se aceptan campos vacios');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al reportar prestamo.');</script>");
            }
        }

        public void modificarPrestamo(string idPrestamo, string idInsumo, string idUsuario, string fecha)
        {
            try
            {
                if (fecha != "")
                {
                    prestamoDAO.modificarPrestamo(Convert.ToInt32(idPrestamo), Convert.ToInt32(idUsuario), Convert.ToInt32(idInsumo), fecha);
                    HttpContext.Current.Response.Redirect("AdministrarPrestamos.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('Espacio solicitado no disponible.');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al modificar prestamo.');</script>");
            }
        }

        public Prestamo buscarPrestamo(string idPrestamo)
        {
            Prestamo prestamo = prestamoDAO.buscarPrestamo(Convert.ToInt32(idPrestamo));
            if (prestamo !=  null)
            {
                return prestamo;
            }
            else
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al obtener prestamo.');</script>");
                return null;
            }
        }

        public void eliminarPrestamo(string idPrestamo)
        {
            try
            {
                prestamoDAO.eliminarPrestamo(Convert.ToInt32(idPrestamo));
                HttpContext.Current.Response.Redirect("AdministrarPrestamos.aspx", true);
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al eliminar prestamo.');</script>");
            }
        }

        public List<Prestamo> obtenerPrestamos()
        {
            try
            {
                return prestamoDAO.obtenerPrestamos();
            }
            catch
            {
                return null;
            }
        }
        
        public void finalizarPrestamo(string idPrestamo)
        {
            try
            {
                prestamoDAO.finalizarPrestamo(Convert.ToInt32(idPrestamo));
                HttpContext.Current.Response.Redirect("AdministrarPrestamos.aspx", true);
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al finalizar prestamo.');</script>");
            }
        }
    }
}