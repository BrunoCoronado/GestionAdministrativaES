using GestionAdministrativaES.Controllers;
using GestionAdministrativaES.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Estudiante.Actividades
{
    public partial class VerActividad : System.Web.UI.Page
    {
        ReservacionControlador reservacionControlador = new ReservacionControlador();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Login.usuario.rol.idRol != 4)
                {
                    switch (Login.usuario.rol.idRol)
                    {
                        case 1:
                            Response.Redirect("../../Administrador/Menu.aspx", true);
                            break;
                        case 2:
                            Response.Redirect("../../OperadorDelSistema/Menu.aspx", true);
                            break;
                        case 3:
                            Response.Redirect("../../Catedratico/Menu.aspx", true);
                            break;
                    }
                }
                else
                {
                    cargarActividad();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../../Login.aspx", true);
            }
        }

        protected void descargarQR_Click(object sender, EventArgs e)
        {
            string codigoQR = reservacionControlador.codigoQRReservacion(lblIdReservacion.InnerText);
            Response.ContentType = "image/png";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + codigoQR + "");
            Response.TransmitFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\codigosQR\\" + codigoQR + "");
            Response.End();
        }

        protected void descargarPresentacion_Click(object sender, EventArgs e)
        {
            try
            {
                string presentacion = reservacionControlador.presentacionReservacion(lblIdReservacion.InnerText);
                if (presentacion != "")
                {
                    Response.ContentType = "file/pptx";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + presentacion + "");
                    Response.TransmitFile(Server.MapPath(Path.Combine("~/App_Data/", presentacion)));
                    Response.End();
                }
            }
            catch
            {

            }
        }

        protected void responderCuestionario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cuestionario.aspx?reservacion=" + lblIdReservacion.InnerText + "", false);
        }

        private void cargarActividad()
        {
            Reservacion reservacion = reservacionControlador.buscarReservacion(Request.QueryString["reservacion"]);
            if (reservacion != null)
            {
                lblIdReservacion.InnerText = reservacion.idReservacion.ToString();
                txtActividad.InnerText = "Actividad: " + reservacion.Actividad;
                txtInstructor.InnerText = "Catedratico: " + reservacion.Usuario.nick;
                txtSalon.InnerText = "Salon: " + reservacion.Salon.ubicacion;
                txtFechaInicio.InnerText = "Fecha Inicio: " + reservacion.FechaInicial;
                txtFechaFin.InnerText = "Fecha Fin:" + reservacion.FechaFinal;
                txtHoraInicio.InnerText = "Hora Inicio: " + reservacion.HoraInicio;
                txtHoraFin.InnerText = "Hora Fin: " + reservacion.HoraFinal;
            }
        }
    }
}