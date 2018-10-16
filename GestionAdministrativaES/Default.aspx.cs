using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                switch (Views.Login.usuario.rol.idRol)
                {
                    case 1:
                        Response.Redirect("Views/Administrador/Menu.aspx", false);
                        break;
                    case 2:
                        Response.Redirect("Views/OperadorDelSistema/Menu.aspx", false);
                        break;
                    case 3:
                        Response.Redirect("Views/Catedratico/Menu.aspx", false);
                        break;
                    case 4:
                        Response.Redirect("Views/Estudiante/Menu.aspx", false);
                        break;
                }
            }
            catch
            {
                Response.Redirect("Views/Login.aspx", true);
            }
        }
    }
}