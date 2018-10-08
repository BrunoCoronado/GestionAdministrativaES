using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Catedratico.Reservaciones
{
    public partial class AdministrarReservaciones : System.Web.UI.Page
    {
        private ReservacionControlador reservacionControlador = new ReservacionControlador();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            Response.ContentType = "image/png";
            Response.AppendHeader("Content-Disposition", "attachment; filename=codigoQR_1015_8.png");
            Response.TransmitFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\codigosQR\\codigoQR_1015_8.png");
            Response.End();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Menu.aspx",true);
        }
    }
}