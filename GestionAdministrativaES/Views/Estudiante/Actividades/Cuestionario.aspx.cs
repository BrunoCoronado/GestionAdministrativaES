using GestionAdministrativaES.Controllers;
using GestionAdministrativaES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Estudiante.Actividades
{
    public partial class Cuestionario : System.Web.UI.Page
    {
        ReservacionControlador reservacionControlador = new ReservacionControlador();
        protected string[] contenido;

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
                    cargarCuestionario();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../../Login.aspx", true);
            }
        }

        public void cargarCuestionario()
        {
            List<Pregunta> preguntas = reservacionControlador.preguntas(Request.QueryString["reservacion"]);
            contenido = new string[preguntas.Count];
            int i = 0;
            foreach (Pregunta pregunta in preguntas)
            {
                contenido[i] = pregunta.pregunta;
                i++;
            }
        }
    }
}