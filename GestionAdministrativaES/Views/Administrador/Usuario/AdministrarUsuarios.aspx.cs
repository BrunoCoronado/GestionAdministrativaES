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
            usuarioControlador.insertarUsuario(ddlRol.SelectedValue,txtNombre.Text,txtCorreo.Text,txtNick.Text,txtContraseña.Text);
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
            catch (Exception ex)
            {

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            usuarioControlador.modificarUsuario(txtIdUsuarioM.Text,ddlRolM.SelectedValue,txtNombreM.Text,txtCorreoM.Text,txtNickM.Text,txtContraseñaM.Text);
            txtIdUsuarioM.Text = "";
            txtNombreM.Text = "";
            txtCorreoM.Text = "";
            txtNickM.Text = "";
            txtContraseñaM.Text = "";
        }
        
    }
}