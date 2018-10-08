using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.OperadorDelSistema
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Salon/AdministrarSalones.aspx", true);
        }

        protected void btnReservaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Salon/Reservacion/AdministrarReservaciones.aspx", true);
        }

        protected void btnIncidentesSalones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Salon/AdministrarIncidentesSalones.aspx", true);
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx", true);
        }
    }
}