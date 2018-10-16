using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Salon
{
    public partial class AdministrarSalones : System.Web.UI.Page
    {
        private SalonControlador salonControlador = new SalonControlador();

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
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../../Login.aspx", true);
            }
        }

        protected void btnAgregarSalon_Click(object sender, EventArgs e)
        {
            salonControlador.insertarSalon(txtUbicacion.Value, txtCapacidad.Value);
            txtUbicacion.Value = "";
            txtCapacidad.Value = "";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            salonControlador.eliminarSalon(((Button)sender).ID.Remove((((Button)sender).ID.Length-1),1));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Models.Salon salon = salonControlador.buscarSalon(((Button)sender).ID);
            if (salon != null)
            {
                lblIdSalonM.InnerText = Convert.ToString(salon.idSalon);
                txtUbicacionM.Value = salon.ubicacion;
                txtCapacidadM.Value = Convert.ToString(salon.capacidad);
                switch (salon.estado)
                {
                    case 0:
                        lblEstadoM.InnerText = "Disponible";
                        break;
                    case 1:
                        lblEstadoM.InnerText = "Reservado";
                        break;
                    case 2:
                        lblEstadoM.InnerText = "Incidente";
                        break;
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            salonControlador.modificarSalon(lblIdSalonM.InnerText, txtUbicacionM.Value, txtCapacidadM.Value);
            lblIdSalonM.InnerText = "";
            lblEstadoM.InnerText = "";
            txtUbicacionM.Value = "";
            txtCapacidadM.Value = "";
        }

        private void llenarTabla()
        {
            List<Models.Salon> salones = salonControlador.listadoSalones();
            if (salones != null)
            {
                foreach (Models.Salon salon in salones)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    for (int i = 0; i < 6; i++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        if (i < 4)
                        {
                            cell.Controls.Add(new LiteralControl(obtenerCampo(salon, i)));
                        }
                        else
                        {
                            cell.Controls.Add(añadirBoton(Convert.ToString(salon.idSalon), i));
                        }
                        row.Cells.Add(cell);
                    }
                    tbSalones.Rows.Add(row);
                }
            }
        }

        private string obtenerCampo(Models.Salon salon, int posicion)
        {
            switch (posicion)
            {
                case 0:
                    return Convert.ToString(salon.idSalon);
                case 1:
                    return salon.ubicacion;
                case 2:
                    return Convert.ToString(salon.capacidad);
                case 3:
                    switch (salon.estado)
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
            return "";
        }

        private Button añadirBoton(string idSalon, int posicion)
        {
            Button button = new Button();
            switch (posicion)
            {
                case 4:
                    button.Text = "Modificar";
                    button.Click += new EventHandler(btnBuscar_Click);
                    button.CssClass = "btn btn-warning";
                    button.ID = idSalon;
                    break;
                case 5:
                    button.Text = "Eliminar";
                    button.Click += new EventHandler(btnEliminar_Click);
                    button.CssClass = "btn btn-danger";
                    button.ID = idSalon + "E";
                    break;
            }
            return button;
        }
    }
}