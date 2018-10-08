using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.OperadorDelSistema.Salon
{
    public partial class AdministrarIncidentesSalones : System.Web.UI.Page
    {
        private SalonIncidenteControlador incidenteSalonControlador = new SalonIncidenteControlador();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReportar_Click(object sender, EventArgs e)
        {
            incidenteSalonControlador.reportarIncidente(Convert.ToString(Login.usuario.idUsuario), ddlSalon.SelectedValue, ddlUsuario.SelectedValue, txtDescripcion.Text, txtFecha.Text);
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            incidenteSalonControlador.finalizarIncidente(ddlInicidentes.SelectedValue);
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Menu.aspx", true);
        }
    }
}