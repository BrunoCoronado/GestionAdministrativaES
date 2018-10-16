using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Administrador.Usuario
{
    public partial class AdministrarUsuarios : System.Web.UI.Page
    {
        private UsuarioControlador usuarioControlador = new UsuarioControlador();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Login.usuario.rol.idRol != 1)
                {
                    switch (Login.usuario.rol.idRol)
                    {
                        case 2:
                            Response.Redirect("../../OperadorDelSistema/Menu.aspx", true);
                            break;
                        case 3:
                            Response.Redirect("../../Catedratico/Menu.aspx", true);
                            break;
                        case 4:
                            Response.Redirect("../../Estudiante/Menu.aspx", true);
                            break;
                    }
                }
                else
                {
                    llenarTabla();
                    llenarListas();
                }
            }
            catch 
            {
                Response.Redirect("../../Login.aspx", true);
            }
        }
        
        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Value.Equals(txtConfirmarContraseña.Value))
            {
                usuarioControlador.insertarUsuario(ddlRol.Value, txtNombre.Value, txtCorreo.Value, txtUsuario.Value, txtContraseña.Value, txtCarnet.Value, txtTelefono.Value, txtPalabraClave.Value);
            }
            else
            {
                Response.Write("<script>window.alert('Error al confirmar contraseña');</script>");
            }
            txtNombre.Value = "";
            txtCorreo.Value = "";
            txtTelefono.Value = "";
            txtCarnet.Value = "";
            txtContraseña.Value = "";
            txtUsuario.Value = "";
            txtPalabraClave.Value = "";
            txtConfirmarContraseña.Value = "";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            usuarioControlador.eliminarUsuario(((Button)sender).ID.Remove((((Button)sender).ID.Length - 1), 1));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Models.Usuario usuario = usuarioControlador.buscarUsuario(((Button)sender).ID);
            if (usuario != null)
            {
                lblIdUsuarioM.InnerText = Convert.ToString(usuario.idUsuario);
                txtNombreM.Value = usuario.nombre;
                txtCorreoM.Value = usuario.correo;
                txtUsuarioM.Value = usuario.nick;
                txtTelefonoM.Value = Convert.ToString(usuario.Telefono);
                txtCarnetM.Value = Convert.ToString(usuario.Carnet);
                txtPalabraClaveM.Value = usuario.PalabraClave;
                ddlRolM.Value = Convert.ToString(usuario.rol.idRol);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            usuarioControlador.modificarUsuario(lblIdUsuarioM.InnerText, ddlRolM.Value, txtNombreM.Value, txtCorreoM.Value, txtUsuarioM.Value, txtCarnetM.Value, txtTelefonoM.Value, txtPalabraClaveM.Value);
            lblIdUsuarioM.InnerText = "";
            txtNombreM.Value = "";
            txtCorreoM.Value = "";
            txtTelefonoM.Value = "";
            txtCarnetM.Value = "";
            txtUsuarioM.Value = "";
            txtPalabraClaveM.Value = "";
        }

        private void llenarTabla()
        {
            List<Models.Usuario> usuarios = usuarioControlador.listaDeUsuarios();
            if (usuarios != null)
            {
                foreach (Models.Usuario usuario in usuarios)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    for (int i = 0; i < 10; i++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        if (i < 8)
                        {
                            cell.Controls.Add(new LiteralControl(obtenerCampo(usuario, i)));
                        }
                        else
                        {
                            if (usuario.rol.idRol != 1)
                            {
                                cell.Controls.Add(añadirBoton(Convert.ToString(usuario.idUsuario), i));
                            }
                        }
                        row.Cells.Add(cell);
                    }
                    tbUsuarios.Rows.Add(row);
                }
            }
        }

        private void llenarListas()
        {
            ddlRol.Items.Add(new ListItem("Operador Del Sistema", "2"));
            ddlRol.Items.Add(new ListItem("Catedratico", "3"));
            ddlRolM.Items.Add(new ListItem("Operador Del Sistema", "2"));
            ddlRolM.Items.Add(new ListItem("Catedratico", "3"));
        }

        private string obtenerCampo(Models.Usuario usuario, int posicion)
        {
            switch (posicion)
            {
                case 0:
                    return Convert.ToString(usuario.idUsuario);
                case 1:
                    return Convert.ToString(usuario.Carnet);
                case 2:
                    return usuario.nombre;
                case 3:
                    return usuario.correo;
                case 4:
                    return Convert.ToString(usuario.Telefono);
                case 5:
                    return usuario.nick;
                case 6:
                    return usuario.rol.nombre;
                case 7:
                    return usuario.PalabraClave;
            }
            return "";
        }

        private Button añadirBoton(string idUsuario, int posicion)
        {
            Button button = new Button();
            switch (posicion)
            {
                case 8:
                    button.Text = "Modificar";
                    button.Click += new EventHandler(btnBuscar_Click);
                    button.CssClass = "btn btn-warning";
                    button.ID = idUsuario;
                    break;
                case 9:
                    button.Text = "Eliminar";
                    button.Click += new EventHandler(btnEliminar_Click);
                    button.CssClass = "btn btn-danger";
                    button.ID = idUsuario+"E";
                    break;
            }
            return button;
        }
    }
}