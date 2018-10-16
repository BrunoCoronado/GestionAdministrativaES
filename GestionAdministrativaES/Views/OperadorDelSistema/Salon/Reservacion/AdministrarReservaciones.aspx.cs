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

namespace GestionAdministrativaES.Views.OperadorDelSistema.Salon.Reservacion
{
    public partial class AdministrarReservaciones : System.Web.UI.Page
    {
        private ReservacionControlador reservacionControlador = new ReservacionControlador();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Login.usuario.rol.idRol != 2)
                {
                    switch (Login.usuario.rol.idRol)
                    {
                        case 1:
                            Response.Redirect("../../../Administrador/Menu.aspx", true);
                            break;
                        case 3:
                            Response.Redirect("../../../Catedratico/Menu.aspx", true);
                            break;
                        case 4:
                            Response.Redirect("../../../Estudiante/Menu.aspx", true);
                            break;
                    }
                }
                else
                {
                    llenarTabla();
                    llenarListas();
                }
            }
            catch 
            {
                Response.Redirect("../../../Login.aspx", true);
            }
        }

        protected void btnComprobaraDisponibilidad_Click(object sender, EventArgs e)
        {
            reservacionControlador.verificarDisponibilidadReservacion(ddlSalonV.Value,txtFechaInicioV.Value,txtFechaFinV.Value,txtHoraInicioV.Value,txtHoraFinV.Value);
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            reservacionControlador.insertarReservacion(ddlUsuario.Value,ddlSalon.Value,Convert.ToString(Login.usuario.idUsuario),ddlPeriodo.Value,ddlActividad.Value,txtHoraInicio.Value,txtHoraFin.Value,txtFechaInicio.Value,txtFechaFin.Value, fcCarta.Value);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            reservacionControlador.eliminarReservacion((((Button)sender).ID).Remove(((Button)sender).ID.Length-1,1));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Models.Reservacion reservacion = reservacionControlador.buscarReservacion(((Button)sender).ID); ;
            if (reservacion != null)
            {
                ddlSalonM.Value = reservacion.Salon.ubicacion;
                ddlPeriodoM.Value = reservacion.Periodo;
                ddlUsuarioM.Value = reservacion.Usuario.nick;
                ddlActividadM.Value= reservacion.Actividad;
                txtFechaInicioM.Value= reservacion.FechaInicial;
                txtFechaFinM.Value = reservacion.FechaFinal;
                txtHoraInicioM.Value = reservacion.HoraInicio;
                txtHoraFinM.Value = reservacion.HoraFinal;
                lblIdReservacionM.InnerText = Convert.ToString(reservacion.idReservacion);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            reservacionControlador.modificarReservacion(lblIdReservacionM.InnerText,ddlUsuarioM.Value,ddlSalonM.Value,"0",ddlPeriodoM.Value,ddlActividadM.Value,txtHoraInicioM.Value,txtHoraFinM.Value,txtFechaInicioM.Value,txtFechaFinM.Value);
        }

        protected void btnAgregarCarta_Click(object sender, EventArgs e)
        {
            reservacionControlador.agregarCartaDeReservacion(lblReservacionC.InnerText, fcCartaC.Value);
        }

        protected void btnCargarAgregarCarta_Click(object sender, EventArgs e)
        {
            lblReservacionC.InnerText = (((Button)sender).ID).Remove((((Button)sender).ID).Length-1,1);
        }

        private void llenarTabla()
        {
            List<Models.Reservacion> reservaciones = reservacionControlador.listaReservaciones();
            if (reservaciones != null)
            {
                foreach (Models.Reservacion reservacion in reservaciones)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    int limite = (reservacion.carta != null) ? 16 : 17;
                    for (int i = 0; i < limite; i++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        if (i < 14)
                        {
                            cell.Controls.Add(new LiteralControl(obtenerCampo(reservacion, i)));
                        }
                        else
                        {
                            cell.Controls.Add(añadirBoton(Convert.ToString(reservacion.idReservacion), i));
                        }
                        row.Cells.Add(cell);
                    }
                    tbReservaciones.Rows.Add(row);
                }
            }
        }

        private void llenarListas()
        {
            ddlPeriodo.Items.Add(new ListItem("Único", "Único"));
            ddlPeriodo.Items.Add(new ListItem("Diario", "Diario"));
            ddlPeriodo.Items.Add(new ListItem("Semanal", "Semanal"));
            ddlPeriodo.Items.Add(new ListItem("Quincenal", "Quincenal"));
            ddlPeriodo.Items.Add(new ListItem("Mensual", "Mensual"));
            ddlPeriodoV.Items.Add(new ListItem("Único", "Único"));
            ddlPeriodoV.Items.Add(new ListItem("Diario", "Diario"));
            ddlPeriodoV.Items.Add(new ListItem("Semanal", "Semanal"));
            ddlPeriodoV.Items.Add(new ListItem("Quincenal", "Quincenal"));
            ddlPeriodoV.Items.Add(new ListItem("Mensual", "Mensual"));
            ddlPeriodoM.Items.Add(new ListItem("Único", "Único"));
            ddlPeriodoM.Items.Add(new ListItem("Diario", "Diario"));
            ddlPeriodoM.Items.Add(new ListItem("Semanal", "Semanal"));
            ddlPeriodoM.Items.Add(new ListItem("Quincenal", "Quincenal"));
            ddlPeriodoM.Items.Add(new ListItem("Mensual", "Mensual"));
            ddlActividad.Items.Add(new ListItem("Laboratorio", "Laboratorio"));
            ddlActividad.Items.Add(new ListItem("Curso Magistral", "Curso Magistral"));
            ddlActividad.Items.Add(new ListItem("Taller", "Taller"));
            ddlActividad.Items.Add(new ListItem("Conferencia", "Conferecia"));
            ddlActividadM.Items.Add(new ListItem("Laboratorio", "Laboratorio"));
            ddlActividadM.Items.Add(new ListItem("Curso Magistral", "Curso Magistral"));
            ddlActividadM.Items.Add(new ListItem("Taller", "Taller"));
            ddlActividadM.Items.Add(new ListItem("Conferencia", "Conferecia"));

            UsuarioControlador usuarioControlador = new UsuarioControlador();
            List<Usuario> usuarios = usuarioControlador.listaDeUsuarios();
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.rol.idRol == 3)
                {
                    ddlUsuario.Items.Add(new ListItem(usuario.nick,Convert.ToString(usuario.idUsuario)));
                    ddlUsuarioM.Items.Add(new ListItem(usuario.nick, Convert.ToString(usuario.idUsuario)));
                }
            }
            SalonControlador salonControlador = new SalonControlador();
            List<Models.Salon> salones = salonControlador.listadoSalones();
            foreach (Models.Salon salon in salones)
            {
                if (salon.estado != 2)
                {
                    ddlSalon.Items.Add(new ListItem(salon.ubicacion, Convert.ToString(salon.idSalon)));
                    ddlSalonM.Items.Add(new ListItem(salon.ubicacion, Convert.ToString(salon.idSalon)));
                    ddlSalonV.Items.Add(new ListItem(salon.ubicacion, Convert.ToString(salon.idSalon)));
                }
            }
        }

        private string obtenerCampo(Models.Reservacion reservacion, int posicion)
        {
            switch (posicion)
            {
                case 0:
                    return Convert.ToString(reservacion.idReservacion);
                case 1:
                    return reservacion.Usuario.nick;
                case 2:
                    return Convert.ToString(reservacion.Salon.idSalon);
                case 3:
                    return reservacion.Salon.ubicacion;
                case 4:
                    return reservacion.Actividad;
                case 5:
                    return reservacion.Periodo;
                case 6:
                    return reservacion.HoraInicio;
                case 7:
                    return reservacion.HoraFinal;
                case 8:
                    return reservacion.FechaInicial;
                case 9:
                    return reservacion.FechaFinal;
                case 10:
                    return reservacion.Operador.nick;
                case 11:
                    string estado = (reservacion.estado == 0) ? "En Proceso" :"Finalizada"; 
                    return estado;
                case 12:
                    return reservacion.carta;
                case 13:
                    return reservacion.CodigoQR;
            }
            return "";
        }

        private Button añadirBoton(string idReservacion, int posicion)
        {
            Button button = new Button();
            switch (posicion)
            {
                case 14:
                    button.Text = "Modificar";
                    button.Click += new EventHandler(btnBuscar_Click);
                    button.CssClass = "btn btn-warning";
                    button.ID = idReservacion;
                    break;
                case 15:
                    button.Text = "Eliminar";
                    button.Click += new EventHandler(btnEliminar_Click);
                    button.CssClass = "btn btn-danger";
                    button.ID = idReservacion + "E";
                    break;
                case 16:
                    button.Text = "Agregar Carta";
                    button.Click += new EventHandler(btnCargarAgregarCarta_Click);
                    button.CssClass = "btn btn-info";
                    button.ID = idReservacion + "C";
                    break;
            }
            return button;
        }
    }
}