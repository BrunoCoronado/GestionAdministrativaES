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
    public partial class VerActividades : System.Web.UI.Page
    {
        protected string[,] actividadesNuevas;
        protected ReservacionControlador reservacionControlador = new ReservacionControlador();
        private MatriculaControlador matriculaControlador = new MatriculaControlador();

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
                    obtenerContenido();
                    if (this.IsPostBack)
                    {
                        matricularse_click(Request.Form[hfName.UniqueID]);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../../Login.aspx", true);
            }
        }

        protected void matricularse_click(string id)
        {
            matriculaControlador.insertarMatricula(id, Login.usuario.idUsuario);
        }

        private void obtenerContenido()
        {
            List<Reservacion> reservaciones = validarActividades(reservacionControlador.listaActividades(), matriculaControlador.listarMatriculas(Login.usuario.idUsuario));

            actividadesNuevas = new string[reservaciones.Count, 6];
            int i = 0;
            foreach (Reservacion reservacion in reservaciones)
            {
                if (reservacion.estado == 1)
                {
                    actividadesNuevas[i, 0] = reservacion.Actividad;
                    actividadesNuevas[i, 1] = reservacion.Usuario.nick;
                    actividadesNuevas[i, 2] = reservacion.Salon.ubicacion;
                    actividadesNuevas[i, 3] = reservacion.FechaInicial;
                    actividadesNuevas[i, 4] = reservacion.HoraInicio;
                    actividadesNuevas[i, 5] = reservacion.idReservacion.ToString();
                    i++;
                }
            }
        }

        private List<Reservacion> validarActividades(List<Reservacion> reservaciones, List<Matricula> matriculas)
        {
            List<Reservacion> resultado = new List<Reservacion>();
            Boolean actividadEnMatricula;
            foreach (Reservacion reservacion in reservaciones)
            {
                actividadEnMatricula = false;
                foreach (Matricula matricula in matriculas)
                {
                    if (matricula.IdReservacion == reservacion.idReservacion)
                    {
                        actividadEnMatricula = true;
                        break;
                    }
                }
                if (!actividadEnMatricula)
                {
                    resultado.Add(reservacion);
                }
            }
            return resultado;
        }
    }
}       