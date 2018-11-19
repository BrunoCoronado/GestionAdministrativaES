using GestionAdministrativaES.Controllers;
using GestionAdministrativaES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Estudiante.Insumos
{
    public partial class AdministrarInsumos : System.Web.UI.Page
    {
        PrestamoControlador prestamoControlador = new PrestamoControlador();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Login.usuario.rol.idRol != 4)
                {
                    switch (Login.usuario.rol.idRol)
                    {
                        case 1:
                            Response.Redirect("../../Administrador/Menu.aspx", true);
                            break;
                        case 2:
                            Response.Redirect("../../OperadorDelSistema/Menu.aspx", true);
                            break;
                        case 3:
                            Response.Redirect("../../Catedratico/Menu.aspx", true);
                            break;
                    }
                }
                else
                {
                    llenarTabla();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../../Login.aspx", true);
            }
        }

        private void llenarTabla()
        {
            List<Prestamo> prestamos = prestamoControlador.obtenerPrestamos();
            if (prestamos != null)
            {
                foreach (Prestamo prestamo in prestamos)
                {
                    if (prestamo.usuario.nick == Login.usuario.nick)
                    {
                        HtmlTableRow row = new HtmlTableRow();
                        for (int i = 0; i < 6; i++)
                        {
                            HtmlTableCell cell = new HtmlTableCell();
                            cell.Controls.Add(new LiteralControl(obtenerCampo(prestamo, i)));
                            row.Cells.Add(cell);
                        }
                        if (prestamo.estado == 0)
                        {
                            tbEnProceso.Rows.Add(row);
                        }
                        else
                        {
                            tbFinalizados.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private string obtenerCampo(Models.Prestamo prestamo, int posicion)
        {
            if (prestamo != null)
            {
                switch (posicion)
                {
                    case 0:
                        return Convert.ToString(prestamo.idPrestamo);
                    case 1:
                        return Convert.ToString(prestamo.insumo.idInsumo);
                    case 2:
                        return prestamo.insumo.nombre;
                    case 3:
                        return prestamo.fecha;
                    case 4:
                        return prestamo.operador.nick;
                    case 5:
                        switch (prestamo.estado)
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