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
            try
            {
                if (Login.usuario.rol.idRol != 2)
                {
                    switch (Login.usuario.rol.idRol)
                    {
                        case 1:
                            Response.Redirect("../Administrador/Menu.aspx", true);
                            break;
                        case 3:
                            Response.Redirect("../Catedratico/Menu.aspx", true);
                            break;
                        case 4:
                            Response.Redirect("../Estudiante/Menu.aspx", true);
                            break;
                    }
                }
            }
            catch 
            {
                Response.Redirect("../Login.aspx", true);
            }
        }
    }
}