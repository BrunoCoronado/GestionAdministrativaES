using GestionAdministrativaES.Controllers;
using GestionAdministrativaES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.OperadorDelSistema.Insumos.Prestamo
{
    public partial class AdministrarPrestamos : System.Web.UI.Page
    {
        PrestamoControlador prestamoControlador = new PrestamoControlador();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Login.usuario.rol.idRol != 2)
                {
                    switch (Login.usuario.rol.idRol)
                    {
                        case 1:
                            Response.Redirect("../../../Administrador/Menu.aspx", true);
                            break;
                        case 3:
                            Response.Redirect("../../../Catedratico/Menu.aspx", true);
                            break;
                        case 4:
                            Response.Redirect("../../../Estudiante/Menu.aspx", true);
                            break;
                    }
                }
                else
                {
                    llenarTabla();
                    llenarListas();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../../../Login.aspx", true);
            }
        }

        protected void CrearPrestamo_Click(object sender, EventArgs e)
        {
            prestamoControlador.insertarPrestamo(ddlInsumo.Value, ddlUsuario.Value, Convert.ToString(Login.usuario.idUsuario), txtFecha.Value);
        }

        protected void ModificarPrestamo_Click(object sender, EventArgs e)
        {
            prestamoControlador.modificarPrestamo(lblIdPrestamoM.InnerText, ddlInsumoM.Value, ddlUsuarioM.Value,txtFechaM.Value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Models.Prestamo prestamo = prestamoControlador.buscarPrestamo(((Button)sender).ID);
            if (prestamo != null)
            {
                lblIdPrestamoM.InnerText = Convert.ToString(prestamo.idPrestamo);
                ddlInsumoM.Value = Convert.ToString(prestamo.insumo.idInsumo);
                ddlUsuarioM.Value = Convert.ToString(prestamo.usuario.idUsuario);
                txtFechaM.Value = prestamo.fecha;
                switch (prestamo.estado)
                {
                    case 0:
                        lblEstadoM.InnerText = "En Proceso";
                        break;
                    case 1:
                        lblEstadoM.InnerText = "Finalizado";
                        break;
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            prestamoControlador.eliminarPrestamo((((Button)sender).ID).Remove((((Button)sender).ID).Length-1,1));
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            prestamoControlador.finalizarPrestamo((((Button)sender).ID).Remove((((Button)sender).ID).Length - 1, 1));
        }

        private void llenarTabla()
        {
            List<Models.Prestamo> prestamos = prestamoControlador.obtenerPrestamos();
            if (prestamos != null)
            {
                foreach (Models.Prestamo prestamo in prestamos)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    for (int i = 0; i < 10; i++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        if (i < 7)
                        {
                            cell.Controls.Add(new LiteralControl(obtenerCampo(prestamo, i)));
                        }
                        else
                        {
                            if (i == 9)
                            {
                                if (prestamo.estado == 0)
                                {
                                    cell.Controls.Add(añadirBoton(Convert.ToString(prestamo.idPrestamo), i));
                                }
                            }
                            else
                            {
                                cell.Controls.Add(añadirBoton(Convert.ToString(prestamo.idPrestamo), i));
                            }
                        }
                        row.Cells.Add(cell);
                    }
                    tbPrestamos.Rows.Add(row);
                }
            }
        }

        private void llenarListas()
        {
            InsumoControlador insumoControlador = new InsumoControlador();
            List<Models.Insumo> insumos = insumoControlador.listaDeInsumos();
            if (insumos != null)
            {
                foreach (Models.Insumo insumo in insumos)
                {
                    if (insumo.estado == 0)
                    {
                        ddlInsumo.Items.Add(new ListItem(Convert.ToString(insumo.idInsumo) + " - " + insumo.nombre, Convert.ToString(insumo.idInsumo)));
                        ddlInsumoM.Items.Add(new ListItem(Convert.ToString(insumo.idInsumo) + " - " + insumo.nombre, Convert.ToString(insumo.idInsumo)));
                    }
                }
            }
            UsuarioControlador usuarioControlador = new UsuarioControlador();
            List<Usuario> usuarios = usuarioControlador.listaDeUsuarios();
            if (usuarios != null)
            {
                foreach (Usuario usuario in usuarios)
                {
                    if (usuario.rol.idRol > 2)
                    {
                        ddlUsuario.Items.Add(new ListItem(usuario.nick + " - " + usuario.rol.nombre, Convert.ToString(usuario.idUsuario)));
                        ddlUsuarioM.Items.Add(new ListItem(usuario.nick + " - " + usuario.rol.nombre, Convert.ToString(usuario.idUsuario)));
                    }
                }
            }

        }

        private string obtenerCampo(Models.Prestamo prestamo, int posicion)
        {
            switch (posicion)
            {
                case 0:
                    return Convert.ToString(prestamo.idPrestamo);
                case 1:
                    return prestamo.usuario.nick;
                case 2:
                    return Convert.ToString(prestamo.insumo.idInsumo);
                case 3:
                    return prestamo.insumo.nombre;
                case 4:
                    return prestamo.operador.nick;
                case 5:
                    return prestamo.fecha;
                case 6:
                    switch (prestamo.estado)
                    {
                        case 0:
                            return "En Proceso";
                        case 1:
                            return "Finalizado";
                    }
                    return "";
            }
            return "";
        }

        private Button añadirBoton(string idPrestamo, int posicion)
        {
            Button button = new Button();
            switch (posicion)
            {
                case 7:
                    button.Text = "Modificar";
                    button.Click += new EventHandler(btnBuscar_Click);
                    button.CssClass = "btn btn-warning";
                    button.ID = idPrestamo;
                    break;
                case 8:
                    button.Text = "Eliminar";
                    button.Click += new EventHandler(btnEliminar_Click);
                    button.CssClass = "btn btn-danger";
                    button.ID = idPrestamo + "E";
                    break;
                case 9:
                    button.Text = "Finalizar";
                    button.Click += new EventHandler(btnFinalizar_Click);
                    button.CssClass = "btn btn-danger";
                    button.ID = idPrestamo + "F";
                    break;
            }
            return button;
        }
    }
}