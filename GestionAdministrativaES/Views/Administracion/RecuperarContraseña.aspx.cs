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
                Models.Usuario usuario = usuarioControlador.validarPalabraClave(txtUsuario.Value, txtPalabraClave.Value);
                lblUsuario.InnerText = usuario.nick;
                lblNombre.InnerText = usuario.nombre;
                lblCarnet.InnerText = Convert.ToString(usuario.Carnet);
            }
            catch
            {

            }
        }

        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Value.Equals(txtConfirmarContraseña.Value) & lblUsuario.InnerText != "")
            {
                usuarioControlador.cambiarContraseña(lblUsuario.InnerText, txtContraseña.Value);
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