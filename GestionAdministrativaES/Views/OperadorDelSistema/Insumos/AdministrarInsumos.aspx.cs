using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.OperadorDelSistema.Insumos
{
    public partial class AdministrarInsumos : System.Web.UI.Page
    {
        private InsumoControlador insumoControlador = new InsumoControlador();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Login.usuario.rol.idRol != 2)
                {
                    switch (Login.usuario.rol.idRol)
                    {
                        case 1:
                            Response.Redirect("../../Administrador/Menu.aspx", true);
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
            catch (Exception ex)
            {
                Response.Redirect("../../Login.aspx", true);
            }
        }
        
        protected void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            insumoControlador.insertarInsumo(txtNombre.Value, ddlTipo.Value);
            txtNombre.Value = "";
        }

        protected void btnModificarInsumo_Click(object sender, EventArgs e)
        {
            insumoControlador.modificarInsumo(lblIdInsumoM.InnerText, ddlTipoM.Value, txtNombreM.Value);
            lblIdInsumoM.InnerText = "";
            txtNombreM.Value = "";
        }

        protected void btnAgregarTipoInsumo_Click(object sender, EventArgs e)
        {
            insumoControlador.insertarTipoInsumo(txtNombreTipoInsumo.Value);
            txtNombreTipoInsumo.Value = "";
        }

        protected void btnModificarTipoInsumo_Click(object sender, EventArgs e)
        {
            insumoControlador.modificarTipoInsumo(lblIdTipoInsumo.InnerText, txtNombreTipoInsumoM.Value);
            lblIdTipoInsumo.InnerText = "";
            txtNombreTipoInsumoM.Value = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string parametro = ((Button)sender).ID;
            if (parametro.Contains("I"))
            {
                Models.Insumo insumo = insumoControlador.buscarInsumo(parametro.Remove(parametro.Length-1,1));
                if (insumo != null)
                {
                    lblIdInsumoM.InnerText = Convert.ToString(insumo.idInsumo);
                    txtNombreM.Value = insumo.nombre;
                    ddlTipoM.Value = Convert.ToString(insumo.tipoInsumo.idTipoInsumo);
                    switch (insumo.estado)
                    {
                        case 0:
                            lblEstadoInsumoM.InnerText = "Disponible";
                            break;
                        case 1:
                            lblEstadoInsumoM.InnerText = "Prestado";
                            break;
                        case 2:
                            lblEstadoInsumoM.InnerText = "Accidente";
                            break;
                    }
                }
            }
            else
            {
                Models.TipoInsumo tipoInsumo = insumoControlador.buscarTipoInsumo(parametro);
                if (tipoInsumo != null)
                {
                    lblIdTipoInsumo.InnerText = Convert.ToString(tipoInsumo.idTipoInsumo);
                    txtNombreTipoInsumoM.Value = tipoInsumo.nombre;
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string parametro = ((Button)sender).ID;
            if (parametro.Contains("I"))
            {
                insumoControlador.eliminarInsumo(parametro.Remove(parametro.Length-2,2));
            }
            else
            {
                insumoControlador.eliminarTipoInsumo(parametro.Remove(parametro.Length - 1, 1));
            }
        }

        private void llenarTabla()
        {
            List<Models.Insumo> insumos = insumoControlador.listaDeInsumos();
            if (insumos != null)
            {
                foreach (Models.Insumo insumo in insumos)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    for (int i = 0; i < 6; i++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        if (i < 4)
                        {
                            cell.Controls.Add(new LiteralControl(obtenerCampo(insumo, null, i)));
                        }
                        else
                        {
                            cell.Controls.Add(añadirBoton(Convert.ToString(insumo.idInsumo),"", i));
                        }
                        row.Cells.Add(cell);
                    }
                    tbInsumos.Rows.Add(row);
                }
            }

            List<Models.TipoInsumo> tipoInsumos = insumoControlador.listaDeTipoInsumos();
            if (tipoInsumos != null)
            {
                foreach (Models.TipoInsumo tipoInsumo in tipoInsumos)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    for (int i = 0; i < 4; i++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        if (i < 2)
                        {
                            cell.Controls.Add(new LiteralControl(obtenerCampo(null, tipoInsumo, i)));
                        }
                        else
                        {
                            cell.Controls.Add(añadirBoton("",Convert.ToString(tipoInsumo.idTipoInsumo),i));
                        }
                        row.Cells.Add(cell);
                    }
                    tbTipoInsumos.Rows.Add(row);
                }
            }

        }

        private void llenarListas()
        {
            List<Models.TipoInsumo> tipoInsumos = insumoControlador.listaDeTipoInsumos();
            if (tipoInsumos != null)
            {
                foreach (Models.TipoInsumo  tipoInsumo in tipoInsumos)
                {
                    ddlTipo.Items.Add(new ListItem(tipoInsumo.nombre, Convert.ToString(tipoInsumo.idTipoInsumo)));
                    ddlTipoM.Items.Add(new ListItem(tipoInsumo.nombre, Convert.ToString(tipoInsumo.idTipoInsumo)));
                }
            }
        }

        private string obtenerCampo(Models.Insumo insumo, Models.TipoInsumo tipoInsumo, int posicion)
        {
            if (insumo != null)
            {
                switch (posicion)
                {
                    case 0:
                        return Convert.ToString(insumo.idInsumo);
                    case 1:
                        return insumo.nombre;
                    case 2:
                        return insumo.tipoInsumo.nombre;
                    case 3:
                        switch (insumo.estado)
                        {
                            case 0:
                                return "Disponible";
                            case 1:
                                return "Reservado";
                            case 2:
                                return "Incidente";
                        }
                        return "";
                }
            }
            else
            {
                switch (posicion)
                {
                    case 0:
                        return Convert.ToString(tipoInsumo.idTipoInsumo);
                    case 1:
                        return tipoInsumo.nombre;
                }
            }
            return "";
        }

        private Button añadirBoton(string idInsumo, string idTipoInsumo, int posicion)
        {
            Button button = new Button();
            if (idInsumo != "")
            {
                switch (posicion)
                {
                    case 4:
                        button.Text = "Modificar";
                        button.Click += new EventHandler(btnBuscar_Click);
                        button.CssClass = "btn btn-warning";
                        button.ID = idInsumo + "I";
                        break;
                    case 5:
                        button.Text = "Eliminar";
                        button.Click += new EventHandler(btnEliminar_Click);
                        button.CssClass = "btn btn-danger";
                        button.ID = idInsumo + "IE";
                        break;
                }
            }
            else
            {
                switch (posicion)
                {
                    case 2:
                        button.Text = "Modificar";
                        button.Click += new EventHandler(btnBuscar_Click);
                        button.CssClass = "btn btn-warning";
                        button.ID = idTipoInsumo;
                        break;
                    case 3:
                        button.Text = "Eliminar";
                        button.Click += new EventHandler(btnEliminar_Click);
                        button.CssClass = "btn btn-danger";
                        button.ID = idTipoInsumo + "E";
                        break;
                }
            }
            return button;
        }
    }
}