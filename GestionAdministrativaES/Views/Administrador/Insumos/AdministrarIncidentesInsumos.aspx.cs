using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Administrador.Insumos
{
    public partial class AdministrarIncidentesInsumos : System.Web.UI.Page
    {
        IncidenteInsumoControlador incideteControlador = new IncidenteInsumoControlador();

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
                }
            }
            catch
            {
                Response.Redirect("../../Login.aspx", true);
            }
        }

        private void llenarTabla()
        {
            List<Models.IncidenteInsumo> incidentes = incideteControlador.obtenerIncidentesInsumos();
            if (incidentes != null)
            {
                foreach (Models.IncidenteInsumo incidente in incidentes)
                {
                    if (incidente.estado == 0)
                    {
                        HtmlTableRow row = new HtmlTableRow();
                        for (int i = 0; i < 5; i++)
                        {
                            HtmlTableCell cell = new HtmlTableCell();
                            cell.Controls.Add(new LiteralControl(obtenerCampo(incidente, i)));
                            row.Cells.Add(cell);
                        }
                        tbPendientes.Rows.Add(row);
                    }
                }
            }
        }

        private string obtenerCampo(Models.IncidenteInsumo incidente, int posicion)
        {
            if (incidente != null)
            {
                switch (posicion)
                {
                    case 0:
                        return Convert.ToString(incidente.idIncidenteInsumo);
                    case 1:
                        return Convert.ToString(incidente.insumo.idInsumo);
                    case 2:
                        return incidente.insumo.nombre;
                    case 3:
                        return incidente.fecha;
                    case 4:
                        switch (incidente.estado)
                        {
                            case 0:
                                return "En Proceso";
                            case 1:
                                return "Finalizado";
                        }
                        return "";
                }
            }
            return "";
        }
    }
}