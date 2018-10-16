using GestionAdministrativaES.Controllers;
using GestionAdministrativaES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.OperadorDelSistema.Salon
{
    public partial class AdministrarIncidentesSalones : System.Web.UI.Page
    {
        private SalonIncidenteControlador incidenteSalonControlador = new SalonIncidenteControlador();

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
        
        protected void btnReportar_Click(object sender, EventArgs e)
        {
            incidenteSalonControlador.reportarIncidente(Convert.ToString(Login.usuario.idUsuario), listaSalones.Value, listaUsuarios.Value, textDescripcion.Value, textFecha.Value);
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            incidenteSalonControlador.finalizarIncidente(((Button)sender).ID);
        }

        private void llenarTabla()
        {
            List<IncidenteSalon> incidenteSalones = incidenteSalonControlador.obtenerIncidentesSalones();
            if (incidenteSalones != null)
            {
                foreach (IncidenteSalon incidenteSalon in incidenteSalones)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    for (int i = 0; i < 8; i++)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        if (i < 7)
                        {
                            cell.Controls.Add(new LiteralControl(obtenerCampo(incidenteSalon, i)));
                        }
                        else
                        {
                            if (incidenteSalon.Estado == 0)
                            {
                                cell.Controls.Add(añadirBoton(Convert.ToString(incidenteSalon.IdIncidenteSalon)));
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
            SalonControlador salonControlador = new SalonControlador();
            List<Models.Salon> salones = salonControlador.listadoSalones();
            if (salones != null)
            {
                foreach (Models.Salon salon in salones)
                {
                    if (salon.estado != 2)
                    {
                        listaSalones.Items.Add(new ListItem(salon.ubicacion, Convert.ToString(salon.idSalon)));
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
                        listaUsuarios.Items.Add(new ListItem(usuario.nick + " - " + usuario.rol.nombre, Convert.ToString(usuario.idUsuario)));
                    }
                }
            }
        }

        private string obtenerCampo(IncidenteSalon incidente, int posicion)
        {
            switch (posicion)
            {
                case 0:
                    return Convert.ToString(incidente.IdIncidenteSalon);
                case 1:
                    return incidente.Salon.ubicacion;
                case 2:
                    return incidente.Usuario.nick;
                case 3:
                    return incidente.Descripcion;
                case 4:
                    return incidente.Fecha;
                case 5:
                    return incidente.Operador.nick;
                case 6:
                    string estado = (incidente.Estado == 0) ? "disponible" : "ocupado";
                    return estado;
            }
            return "";
        }

        private Button añadirBoton(string idIncidente)
        {
            Button button = new Button();
            button.ID = idIncidente;
            button.Text = "Finalizar";
            button.Click += new EventHandler(btnFinalizar_Click);
            button.CssClass = "btn btn-warning";
            return button;
        }
    }
}   