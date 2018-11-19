using GestionAdministrativaES.Models;
using GestionAdministrativaES.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Controllers
{
    public class InsumoControlador
    {
        private InsumoDAO insumoDAO = new InsumoDAO();

        public List<Insumo> listaDeInsumos()
        {
            try
            {
                return insumoDAO.listaDeInsumos();
            }
            catch
            {
                return null;
            }
        } 

        public void insertarInsumo(string nombre, string tipoInsumo)
        {
            try
            {
                if(nombre != "")
                {
                    insumoDAO.insertarInsumo(Convert.ToInt32(tipoInsumo), nombre, 0);
                    HttpContext.Current.Response.Redirect("AdministrarInsumos.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('No se permiten espacios en blanco!');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al registrar insumo!');</script>");
            }
        }

        public void eliminarInsumo(string idInsumo)
        {
            try
            {
                insumoDAO.eliminarInsumo(Convert.ToInt32(idInsumo));
                HttpContext.Current.Response.Redirect("AdministrarInsumos.aspx", true);
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al eliminar insumo.');</script>");
            }
        }

        public void modificarInsumo(string idInsumo, string idTipoInsumo, string nombre)
        {
            try
            {
                if (nombre != "")
                {
                    insumoDAO.modificarInsumo(Convert.ToInt32(idInsumo), nombre, Convert.ToInt32(idTipoInsumo));
                    HttpContext.Current.Response.Redirect("AdministrarInsumos.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('No se permiten espacios en blanco!');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al modificar insumo.');</script>");
            }
        }

        public Insumo buscarInsumo(string idInsumo)
        {
            Insumo insumo = insumoDAO.buscarInsumo(Convert.ToInt32(idInsumo));
            if (insumo != null)
            {
                return insumo;
            }
            else
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al obtener insumo');</script>");
                return null;
            }
        }

        public List<TipoInsumo> listaDeTipoInsumos()
        {
            try
            {
                return insumoDAO.listaDeTipoDeInsumos();
            }
            catch
            {
                return null;
            }
        }

        public void insertarTipoInsumo(string nombre)
        {
            try
            {
                if (nombre != "")
                {
                    insumoDAO.insertarTipoInsumo(nombre);
                    HttpContext.Current.Response.Redirect("AdministrarInsumos.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('No se permiten espacios en blanco!');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al registrar tipo insumo!');</script>");
            }
        }

        public void eliminarTipoInsumo(string idTipoInsumo)
        {
            try
            {
                insumoDAO.eliminarTipoInsumo(Convert.ToInt32(idTipoInsumo));
                HttpContext.Current.Response.Redirect("AdministrarInsumos.aspx", true);
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al eliminar insumo.');</script>");
            }
        }

        public void modificarTipoInsumo(string idTipoInsumo, string nombre)
        {
            try
            {
                if (nombre != "")
                {
                    insumoDAO.modificarTipoInsumo(nombre, Convert.ToInt32(idTipoInsumo));
                    HttpContext.Current.Response.Redirect("AdministrarInsumos.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('No se permiten espacios en blanco!');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al modificar tipo insumo.');</script>");
            }
        }

        public TipoInsumo buscarTipoInsumo(string idTipoInsumo)
        {
            TipoInsumo tipoInsumo = insumoDAO.buscarTipoInsumo(Convert.ToInt32(idTipoInsumo));
            if (tipoInsumo != null)
            {
                return tipoInsumo;
            }
            else
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al obtener tipo insumo');</script>");
                return null;
            }
        }
    }
}