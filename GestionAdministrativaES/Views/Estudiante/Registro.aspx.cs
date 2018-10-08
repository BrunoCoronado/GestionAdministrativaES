using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Estudiante
{
    public partial class Registro : System.Web.UI.Page
    {
        private UsuarioControlador usuarioControlador = new UsuarioControlador();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Equals(txtConfirmarContraseña.Text))
            {
                usuarioControlador.registrarUsuario("4", txtNombre.Text, txtCorreo.Text, txtNick.Text, txtContraseña.Text, txtCarnet.Text, txtTelefono.Text, txtPalabraClave.Text);
            }
            else
            {
                Response.Write("<script>window.alert('Error al confirmar contraseña');</script>");
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx", true);
        }
    }
}