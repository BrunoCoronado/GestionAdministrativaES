﻿using GestionAdministrativaES.Models;
using GestionAdministrativaES.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Controllers
{
    public class SalonControlador
    {
        private SalonDAO salonDAO = new SalonDAO();

        public void insertarSalon(string ubicacion, string capacidad)
        {
            try
            {
                if (ubicacion != "" & capacidad != "")
                {
                    salonDAO.insertarSalon(ubicacion, Convert.ToInt32(capacidad));
                    HttpContext.Current.Response.Redirect("AdministrarSalones.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('Ubicacion no puede estar vacia!');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Capacidad debe ser un numero entero!');</script>");
            }
            
        }

        public void eliminarSalon(string idSalon)
        {
            try
            {
                salonDAO.eliminarSalon(Convert.ToInt32(idSalon));
                HttpContext.Current.Response.Redirect("AdministrarSalones.aspx", true);
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al eliminar!');</script>");
            }
        }

        public Salon buscarSalon(string idSalon)
        {
            Salon salon = salonDAO.buscarSalon(Convert.ToInt32(idSalon));

            if (salon != null) {
                return salon;
            }
            else
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al obtener salon');</script>");
                return null;
            }
        }

        public void modificarSalon(string idSalon, string ubicacion, string capacidad)
        {
            try
            {
                if (ubicacion != "" & capacidad != "")
                {
                    salonDAO.modificarSalon(Convert.ToInt32(idSalon), ubicacion, Convert.ToInt32(capacidad));
                    HttpContext.Current.Response.Redirect("AdministrarSalones.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('Ubicacion no puede estar vacia!');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Seleccionar un elemento y verificar capacidad numero entero!');</script>");
            }
        }

        public List<Salon> listadoSalones()
        {
            try
            {
                return salonDAO.listadoSalones();
            }
            catch
            {
                return null;
            }
        }
    }
}