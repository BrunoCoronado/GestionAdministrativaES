using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Salon
{
    public partial class AdministrarSalones : System.Web.UI.Page
    {
        private SalonControlador salonControlador = new SalonControlador();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarSalon_Click(object sender, EventArgs e)
        {
            salonControlador.insertarSalon(txtUbicacion.Text, txtCapacidad.Text);
            txtUbicacion.Text = "";
            txtCapacidad.Text = "";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            salonControlador.eliminarSalon(DropDownListEliminar.SelectedValue);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Salon salon = salonControlador.buscarSalon(Convert.ToInt32(DropDownListModificar.SelectedValue));
                txtIdSalonM.Text = Convert.ToString(salon.idSalon);
                txtUbicacionM.Text = salon.ubicacion;
                txtCapacidadM.Text = Convert.ToString(salon.capacidad);
            }
            catch
            {
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            salonControlador.modificarSalon(txtIdSalonM.Text, txtUbicacionM.Text, txtCapacidadM.Text);
            txtIdSalonM.Text = "";
            txtUbicacionM.Text = "";
            txtCapacidadM.Text = "";
        }
    }
}