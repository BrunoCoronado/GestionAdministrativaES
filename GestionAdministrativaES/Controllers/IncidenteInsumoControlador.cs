using GestionAdministrativaES.Models;
using GestionAdministrativaES.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Controllers
{
    public class IncidenteInsumoControlador
    {
        IncidenteInsumoDAO incidenteInsumoDAO = new IncidenteInsumoDAO();

        public void reportarIncidente(string idInsumo, string idUsuario, string fecha)
        {
            try
            {
                if (fecha != "")
                {
                    incidenteInsumoDAO.reportarIncidente(Convert.ToInt32(idUsuario), Convert.ToInt32(idInsumo), fecha, 0);
                    HttpContext.Current.Response.Redirect("AdministrarIncidentesInsumos.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('No se aceptan campos vacios');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al reportar incidente.');</script>");
            }
        }

        public void finalizarIncidente(string idIncidente)
        {
            try
            {
                incidenteInsumoDAO.finalizarIncidente(Convert.ToInt32(idIncidente), 1);
                HttpContext.Current.Response.Redirect("AdministrarIncidentesInsumos.aspx", true);
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al finalizar incidente.');</script>");
            }
        }

        public List<IncidenteInsumo> obtenerIncidentesInsumos()
        {
            try
            {
                return incidenteInsumoDAO.obtenerIncidentesInsuos();
            }
            catch
            {
                return null;
            }
        } 
    }
}