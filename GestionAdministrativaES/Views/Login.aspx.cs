using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            UsuarioControlador usuarioControlador = new UsuarioControlador();
            usuarioControlador.validarInicioSesion(txtUsuario.Text, txtContraseña.Text);
        }

        protected void btnRegistrarEstudiante_Click(object sender, EventArgs e)
        {
            UsuarioControlador usuarioControlador = new UsuarioControlador();
            usuarioControlador.
        }
    }
}