using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCerrar_Sesion(object sender, EventArgs e)
        {
            Views.Login.usuario = null;
            Response.Redirect("Views/Login.aspx", true);
        }
    }
}