using GestionAdministrativaES.Controllers;
using GestionAdministrativaES.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        protected void btnSubirPresentacion_Click(object sender, EventArgs e)
        {
            Models.Reservacion reservacion = reservacionControlador.buscarReservacion(((Button)sender).ID.Remove(((Button)sender).ID.Length-1,1));
            if (reservacion != null)
            {
                lblReservacionP.InnerText = reservacion.idReservacion.ToString();
            }
        }
        
        protected void btnInsertarPresentacion_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files["ctl00$MainContent$fcPresentacion"];

            //check file was submitted
            if (file != null && file.ContentLength > 0)
            {
                string fname = Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath(Path.Combine("~/App_Data/", fname)));
                reservacionControlador.agregarPresentacion(lblReservacionP.InnerText, fname);
            }
            lblReservacionP.InnerText = "";
        }

        protected void btnAgregarCuestionario_Click(object sender, EventArgs e)
        {
            limpiarTablaCuestionario();   
            Models.Reservacion reservacion = reservacionControlador.buscarReservacionCuestionario(((Button)sender).ID.Remove(((Button)sender).ID.Length - 1, 1));
            if (reservacion != null)
            {
                lblReservacionC.InnerText = reservacion.idReservacion.ToString();
                if (reservacion.cuestionario != 0)
                {
                    List<Pregunta> preguntas = reservacionControlador.preguntasCuestionario(reservacion.cuestionario);
                    llenarTablaPreguntas(preguntas);
                    lblIdCuestionario.InnerText = reservacion.cuestionario.ToString();
                }
                else
                {
                    
                    int idCuestionario = reservacionControlador.agregarCuestionario(reservacion.idReservacion.ToString());
                    lblIdCuestionario.InnerText = idCuestionario.ToString();
                }
            }
        }

        protected void btnAgregarPregunta_Click(object sender, EventArgs e)
        {
            Models.Pregunta pregunta = reservacionControlador.agregarPregunta(lblIdCuestionario.InnerText, txtPregunta.Value);
            if (pregunta != null)
            {
                limpiarTablaCuestionario();
                List<Pregunta> preguntas = reservacionControlador.preguntasCuestionario(Convert.ToInt32(lblIdCuestionario.InnerText));
                llenarTablaPreguntas(preguntas);
            }
            txtPregunta.Value = "";
        }

        protected void btnEliminarPregunta_Click(object sender, EventArgs e)
        {

        }

        private void llenarTabla()
        {
            List<Reservacion> reservaciones = reservacionControlador.listaReservaciones();
            if (reservaciones != null)
            {
                foreach (Reservacion reservacion in reservaciones)
                {
                    if (reservacion.Usuario.idUsuario == Login.usuario.idUsuario)
                    {
                        HtmlTableRow row = new HtmlTableRow();
                        for (int i = 0; i < 13; i++)
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
                                    cell.Controls.Add(añadirBoton(Convert.ToString(reservacion.idReservacion), i));
                                }
                            }
                            row.Cells.Add(cell);
                        }
                        tbReservaciones.Rows.Add(row);
                    }
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

        private Button añadirBoton(string idReservacion, int posicion)
        {
            Button button = new Button();
            switch (posicion)
            {
                case 10:
                    button.ID = idReservacion;
                    button.Text = "Descargar";
                    button.Click += new EventHandler(btnDescargar_Click);
                    button.CssClass = "btn btn-dark";
                    break;
                case 11:
                    button.ID = idReservacion + "P";
                    button.Text = "Presentacion";
                    button.Click += new EventHandler(btnSubirPresentacion_Click);
                    button.CssClass = "btn btn-dark";
                    break;
                case 12:
                    button.ID = idReservacion + "C";
                    button.Text = "Cuestionario";
                    button.Click += new EventHandler(btnAgregarCuestionario_Click);
                    button.CssClass = "btn btn-dark";
                    break;
            }
            return button;
        }

        private void llenarTablaPreguntas(List<Pregunta> preguntas)
        {
            if (preguntas != null)
            {
                foreach (Pregunta pregunta in preguntas)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    for (int i = 0; i < 4; i++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        if (i < 3)
                        {
                            cell.Controls.Add(new LiteralControl(obtenerCampoPregunta(pregunta, i)));
                        }
                        else
                        {
                            cell.Controls.Add(añadirBotonPregunta(Convert.ToString(pregunta.idPregunta)));
                        }
                        row.Cells.Add(cell);
                    }
                    tbCuestionario.Rows.Add(row);
                }
            }
        }

        private string obtenerCampoPregunta(Pregunta pregunta, int posicion)
        {
            switch (posicion)
            {
                case 0:
                    return Convert.ToString(pregunta.idPregunta);
                case 1:
                    return Convert.ToString(pregunta.idCuestionario);
                case 2:
                    return pregunta.pregunta;
            }
            return "";
        }

        private Button añadirBotonPregunta(string idPregunta)
        {
            Button button = new Button();
            button.ID = idPregunta;
            button.Text = "Eliminar";
            button.Click += new EventHandler(btnEliminarPregunta_Click);
            button.CssClass = "btn btn-danger";
            return button;
        }

        private void limpiarTablaCuestionario()
        {
            for (int i = 1; i < tbCuestionario.Rows.Count; i++)
            {
                tbCuestionario.Rows.RemoveAt(i);
            }
        }
    }
}