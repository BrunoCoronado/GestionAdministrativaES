using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Administracion
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        private UsuarioControlador usuarioControlador = new UsuarioControlador();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bntValidarPalabraClave_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Usuario usuario = usuarioControlador.validarPalabraClave(txtNickVPC.Text, txtPalabraClaveVPC.Text);
                lblUsuario.Text = usuario.nick;
                lblNombre.Text = usuario.nombre;
                lblCorreo.Text = usuario.correo;
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Equals(txtContraseñaR.Text) & lblUsuario.Text != "")
            {
                usuarioControlador.cambiarContraseña(lblUsuario.Text, txtContraseñaR.Text);
            }
            else
            {
                Response.Write("<script>window.alert('Error! Verificar Palabra Clave y Contraseña');</script>");
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx", true);
        }
    }
}