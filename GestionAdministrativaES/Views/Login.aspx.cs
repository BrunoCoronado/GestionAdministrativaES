using GestionAdministrativaES.Controllers;
using GestionAdministrativaES.Models;
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
        public static Usuario usuario = new Usuario();
        private UsuarioControlador usuarioControlador = new UsuarioControlador();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            usuarioControlador.validarInicioSesion(txtUsuario.Text, txtContraseña.Text);
        }

        protected void btnRegistrarEstudiante_Click(object sender, EventArgs e)
        {
            Response.Redirect("Estudiante/Registro.aspx",true);
        }

        protected void btnRecuperarContraseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administracion/RecuperarContraseña.aspx", true);
        }
    }
}