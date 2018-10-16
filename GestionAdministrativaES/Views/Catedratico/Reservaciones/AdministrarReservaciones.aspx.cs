using GestionAdministrativaES.Controllers;
using GestionAdministrativaES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Catedratico.Reservaciones
{
    public partial class AdministrarReservaciones : System.Web.UI.Page
    {
        private ReservacionControlador reservacionControlador = new ReservacionControlador();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Login.usuario.rol.idRol != 3)
                {
                    switch (Login.usuario.rol.idRol)
                    {
                        case 1:
                            Response.Redirect("../../Administrador/Menu.aspx", true);
                            break;
                        case 2:
                            Response.Redirect("../../OperadorDelSistema/Menu.aspx", true);
                            break;
                        case 4:
                            Response.Redirect("../../Estudiante/Menu.aspx", true);
                            break;
                    }
                }
                else
                {
                    llenarTabla();
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("../../Login.aspx", true);
            }
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            string codigoQR = reservacionControlador.codigoQRReservacion(((Button)sender).ID);
            Response.ContentType = "image/png";
            Response.AppendHeader("Content-Disposition", "attachment; filename="+codigoQR+"");
            Response.TransmitFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\codigosQR\\"+codigoQR+"");
            Response.End();
        }

        private void llenarTabla()
        {
            List<Reservacion> reservaciones = reservacionControlador.listaReservaciones();
            if (reservaciones != null)
            {
                foreach (Reservacion reservacion in reservaciones)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    for (int i = 0; i < 11; i++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        if (i < 10)
                        {
                            cell.Controls.Add(new LiteralControl(obtenerCampo(reservacion, i)));
                        }
                        else
                        {
                            if (reservacion.estado != 0)
                            {
                                cell.Controls.Add(añadirBoton(Convert.ToString(reservacion.idReservacion)));
                            }
                        }
                        row.Cells.Add(cell);
                    }
                    tbReservaciones.Rows.Add(row);
                }
            }
        }

        private string obtenerCampo(Reservacion reservacion, int posicion)
        {
            switch (posicion)
            {
                case 0:
                    return Convert.ToString(reservacion.idReservacion);
                case 1:
                    return Convert.ToString(reservacion.Salon.idSalon);
                case 2:
                    return reservacion.Salon.ubicacion;
                case 3:
                    return reservacion.Actividad;
                case 4:
                    return reservacion.Periodo;
                case 5:
                    return reservacion.HoraInicio;
                case 6:
                    return reservacion.HoraFinal;
                case 7:
                    return reservacion.FechaInicial;
                case 8:
                    return reservacion.FechaFinal;
                case 9:
                    string estado = (reservacion.estado == 0) ? "En Proceso" :"Finalizada";
                    return estado;
            }
            return "";
        }

        private Button añadirBoton(string idReservacion)
        {
            Button button = new Button();
            button.ID = idReservacion;
            button.Text = "Descargar";
            button.Click += new EventHandler(btnDescargar_Click);
            button.CssClass = "btn btn-dark";
            return button;
        }
    }
}