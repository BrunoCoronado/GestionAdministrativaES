using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Administrador.Usuario
{
    public partial class AdministrarUsuarios : System.Web.UI.Page
    {
        private UsuarioControlador usuarioControlador = new UsuarioControlador();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Equals(txtConfirmarContraseña.Text))
            {
                usuarioControlador.insertarUsuario(ddlRol.SelectedValue, txtNombre.Text, txtCorreo.Text, txtNick.Text, txtContraseña.Text, txtCarnet.Text, txtTelefono.Text, txtPalabraClave.Text);
            }
            else
            {
                Response.Write("<script>window.alert('Error al confirmar contraseña');</script>");
            }
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtNick.Text = "";
            txtContraseña.Text = "";
            ddlRol.ClearSelection();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            usuarioControlador.eliminarUsuario(DropDownListEliminar.SelectedValue);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Usuario usuario = usuarioControlador.buscarUsuario(DropDownListModificar.SelectedValue);
                txtIdUsuarioM.Text = Convert.ToString(usuario.idUsuario);
                txtNombreM.Text = usuario.nombre;
                txtCorreoM.Text = usuario.correo;
                txtNickM.Text = usuario.nick;
                txtContraseñaM.Text = usuario.contraseña;
                ddlRolM.ClearSelection();
                ddlRolM.Items.FindByValue(Convert.ToString(usuario.rol.idRol)).Selected = true;
            }
            catch
            {

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtContraseñaM.Text.Equals(txtConfirmarContraseñaM.Text))
            {
                usuarioControlador.modificarUsuario(txtIdUsuarioM.Text, ddlRolM.SelectedValue, txtNombreM.Text, txtCorreoM.Text, txtNickM.Text, txtContraseñaM.Text, txtCarnetM.Text, txtTelefonoM.Text, txtPalabraClaveM.Text);
            }
            else
            {
                Response.Write("<script>window.alert('Error al confirmar contraseña');</script>");
            }
            txtIdUsuarioM.Text = "";
            txtNombreM.Text = "";
            txtCorreoM.Text = "";
            txtNickM.Text = "";
            txtContraseñaM.Text = "";
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Menu.aspx",true);
        }
    }
}