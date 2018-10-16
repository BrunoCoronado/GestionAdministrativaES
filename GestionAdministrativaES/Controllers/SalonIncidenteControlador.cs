using GestionAdministrativaES.Models;
using GestionAdministrativaES.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Controllers
{
    public class SalonIncidenteControlador
    {
        IncidenteSalonDAO incidenteSalonDAO = new IncidenteSalonDAO();

        public void reportarIncidente(string idOperador, string idSalon, string idUsuario, string descripcion, string fecha)
        {
            try
            {
                if (descripcion != "" & fecha != "")
                {
                    incidenteSalonDAO.reportarIncidente(Convert.ToInt32(idOperador), Convert.ToInt32(idSalon), Convert.ToInt32(idUsuario), descripcion, fecha, 0);
                    HttpContext.Current.Response.Redirect("AdministrarIncidentesSalones.aspx", true);
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
                incidenteSalonDAO.finalizarIncidente(Convert.ToInt32(idIncidente), 1);
                HttpContext.Current.Response.Redirect("AdministrarIncidentesSalones.aspx", true);
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al finalizar incidente.');</script>");
            }
        }

        public List<IncidenteSalon> obtenerIncidentesSalones()
        {
            try
            {
                List<IncidenteSalon> incidentes = incidenteSalonDAO.obtenerIncidentesSalones();
                return incidentes;
            }
            catch
            {
                return null;
            }
        }
    }
}