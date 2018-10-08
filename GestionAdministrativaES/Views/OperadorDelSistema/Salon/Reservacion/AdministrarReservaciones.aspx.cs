using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.OperadorDelSistema.Salon.Reservacion
{
    public partial class AdministrarReservaciones : System.Web.UI.Page
    {
        private ReservacionControlador reservacionControlador = new ReservacionControlador();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnComprobaraDisponibilidad_Click(object sender, EventArgs e)
        {
            reservacionControlador.verificarDisponibilidadReservacion(ddlSalonesVD.SelectedValue,txtFechaInicioVD.Text,txtFechaFinVD.Text,txtHoraInicioVD.Text,txtHoraFinVD.Text);
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            reservacionControlador.insertarReservacion(ddlUsuario.SelectedValue,ddlSalon.SelectedValue,Convert.ToString(Login.usuario.idUsuario),ddlPeriodo.SelectedValue,txtActividad.Text,txtHoraInicio.Text,txtHoraFin.Text,txtFechaInicio.Text,txtFechaFIn.Text, Path.GetFileName(FUInsertarCarta.FileName));
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            reservacionControlador.eliminarReservacion(ddlReservacionEliminar.SelectedValue);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Reservacion reservacion = reservacionControlador.buscarReservacion(ddlReservacionEditar.SelectedValue); ;
                ddlSalonM.ClearSelection();
                ddlPeriodoM.ClearSelection();
                ddlUsuarioM.ClearSelection();
                ddlSalonM.Items.FindByValue(Convert.ToString(reservacion.idSalon)).Selected = true;
                ddlPeriodoM.Items.FindByValue(reservacion.Periodo).Selected = true;
                ddlUsuarioM.Items.FindByValue(Convert.ToString(reservacion.idUsuario)).Selected = true;
                txtActividadM.Text = reservacion.Actividad;
                txtFechaInicioM.Text = reservacion.FechaInicial;
                txtFechaFinM.Text = reservacion.FechaFinal;
                txtHoraInicioM.Text = reservacion.HoraInicio;
                txtHoraFinM.Text = reservacion.HoraFinal;
                txtIdReservacionM.Text = Convert.ToString(reservacion.idReservacion);
            }
            catch
            {

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            reservacionControlador.modificarReservacion(txtIdReservacionM.Text,ddlUsuarioM.SelectedValue,ddlSalonM.SelectedValue,"0",ddlPeriodoM.SelectedValue,txtActividadM.Text,txtHoraInicioM.Text,txtHoraFinM.Text,txtFechaInicioM.Text,txtFechaFinM.Text);
        }

        protected void btnAgregarCarta_Click(object sender, EventArgs e)
        {
            reservacionControlador.agregarCartaDeReservacion(ddlSalonAC.SelectedValue, Path.GetFileName(FUAgregarCarta.FileName));
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Menu.aspx", true);
        }
    }
}