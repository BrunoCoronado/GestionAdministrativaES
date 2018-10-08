using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Administrador
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Administrador/Usuario/AdministrarUsuarios.aspx", true);
        }

        protected void btnCargaMasiva_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Administracion/CargaMasiva.aspx", true);
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx", true);
        }
    }
}