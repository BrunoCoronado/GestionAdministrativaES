using GestionAdministrativaES.Models;
using GestionAdministrativaES.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Controllers
{
    public class MatriculaControlador
    {
        private MatriculaDAO matriculaDAO = new MatriculaDAO();

        public void insertarMatricula(string idReservacion, int idUsuario)
        {
            try
            {
                if (idReservacion != "")
                {
                    int cupo = matriculaDAO.obtenerCupoActividad(Convert.ToInt32(idReservacion));
                    if (cupo < 25)
                    {
                        matriculaDAO.insertarMatricula(Convert.ToInt32(idReservacion), idUsuario, cupo);
                        HttpContext.Current.Response.Redirect("VerActividad.aspx?reservacion="+idReservacion+"", false);
                    }
                    else
                    {
                        HttpContext.Current.Response.Write("<script>window.alert('Cupo Lleno!');</script>");
                    }
                }
            }
            catch
            {

            }
        }

        public List<Matricula> listarMatriculas(int idUsuario)
        {
            try
            {
                return matriculaDAO.listarMatriculas(Convert.ToInt32(idUsuario));
            }
            catch
            {
                return null;
            }
        }
    }
}