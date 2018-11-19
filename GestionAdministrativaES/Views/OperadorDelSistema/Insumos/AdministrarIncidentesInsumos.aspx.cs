using GestionAdministrativaES.Controllers;
using GestionAdministrativaES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.OperadorDelSistema.Insumos
{
    public partial class AdministrarIncidentesInsumos : System.Web.UI.Page
    {
        private IncidenteInsumoControlador incidenteInsumoControlador = new IncidenteInsumoControlador();

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

        protected void ReportarIncidente_Click(object sender, EventArgs e)
        {
            incidenteInsumoControlador.reportarIncidente(ddlInsumos.Value, ddlUsuarios.Value, txtFecha.Value);
        }

        protected void FinalizarIncidente_Click(object sender, EventArgs e)
        {
            incidenteInsumoControlador.finalizarIncidente(((Button)sender).ID);
        }

        private void llenarTabla()
        {
            List<Models.IncidenteInsumo> incidenteInsumos = incidenteInsumoControlador.obtenerIncidentesInsumos();
            if (incidenteInsumos != null)
            {
                foreach (Models.IncidenteInsumo incidenteInsumo in incidenteInsumos)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    for (int i = 0; i < 7; i++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        if (i < 6)
                        {
                            cell.Controls.Add(new LiteralControl(obtenerCampo(incidenteInsumo, i)));
                        }
                        else
                        {
                            if (incidenteInsumo.estado == 0)
                            {
                                cell.Controls.Add(añadirBoton(Convert.ToString(incidenteInsumo.idIncidenteInsumo)));
                            }
                        }
                        row.Cells.Add(cell);
                    }
                    tbIncidentes.Rows.Add(row);
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
                        ddlInsumos.Items.Add(new ListItem(Convert.ToString(insumo.idInsumo) + " - " + insumo.nombre, Convert.ToString(insumo.idInsumo)));
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
                        ddlUsuarios.Items.Add(new ListItem(usuario.nick + " - " + usuario.rol.nombre, Convert.ToString(usuario.idUsuario)));
                    }
                }
            }

        }

        private string obtenerCampo(Models.IncidenteInsumo incidenteInsumo, int posicion)
        {
            switch (posicion)
            {
                case 0:
                    return Convert.ToString(incidenteInsumo.idIncidenteInsumo);
                case 1:
                    return Convert.ToString(incidenteInsumo.insumo.idInsumo);
                case 2:
                    return incidenteInsumo.insumo.nombre;
                case 3:
                    return incidenteInsumo.usuario.nick;
                case 4:
                    return incidenteInsumo.fecha;
                case 5:
                    switch (incidenteInsumo.estado)
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

        private Button añadirBoton(string idIncidenteInsumo)
        {
            Button button = new Button();
            button.ID = idIncidenteInsumo;
            button.Text = "Finalizar";
            button.Click += new EventHandler(FinalizarIncidente_Click);
            button.CssClass = "btn btn-warning";
            return button;
        }
    }
}