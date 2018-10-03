using GestionAdministrativaES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Controllers
{
    public class UsuarioControlador
    {
        private UsuarioDAO usuarioDAO = new UsuarioDAO();

        public void validarInicioSesion(string nick, string contraseña)
        {
            Usuario usuario = usuarioDAO.iniciarSesion(nick, contraseña);
            if (usuario != null)
            {
                HttpContext.Current.Response.Write("<script>window.alert('Bienvenido al Sistema');</script>");
                string pagina = "/Menu.aspx";
                switch (usuario.rol.nombre)
                {
                    case "Administrador":
                        pagina = "/Views/Administrador" + pagina;
                        break;
                    case "Operador Del Sistema":
                        pagina = "/Views/OperadorDelSistema" + pagina;
                        break;
                    case "Catedratico":
                        pagina = "/Views/Catedratico" + pagina;
                        break;
                    case "Estudiante":
                        pagina = "/Views/Estudiante" + pagina;
                        break;
                      
                }
                HttpContext.Current.Response.Redirect(pagina, true);
            }
            else
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al iniciar sesión');</script>");
            }
        }

        public void registrarUsuario(String idRol, string nombre, string correo, string nick, string contraseña)
        {
            try
            {
                if (nombre != "" & correo != "" & nick != "" & contraseña != "")
                {
                    if (usuarioDAO.registrarUsuario(Convert.ToInt32(idRol), nombre, correo, nick, contraseña))
                    {
                        HttpContext.Current.Response.Write("<script>window.alert('Estudiante registrado!');</script>");
                        HttpContext.Current.Response.Redirect("", true);
                    }
                    else
                    {
                        HttpContext.Current.Response.Write("<script>window.alert('Error al registrarse');</script>");
                        HttpContext.Current.Response.Redirect("", true);
                    }
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('No se permiten espacios en blanco!');</script>");
                }
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al registrar usuario!');</script>");
            }
        }

        public void insertarUsuario(string idRol, string nombre, string correo, string nick, string contraseña)
        {
            try
            {
                if (nombre != "" & correo != "" & nick != "" & contraseña != "")
                {
                    usuarioDAO.insertarUsuario(Convert.ToInt32(idRol), nombre, correo, nick, contraseña);
                    HttpContext.Current.Response.Redirect("../Usuario/AdministrarUsuarios.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('No se permiten espacios en blanco!');</script>");
                }
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al registrar usuario!');</script>");
            }
        }

        public Usuario buscarUsuario(String idUsuario)
        {
            Usuario usuario = usuarioDAO.buscarUsuario(Convert.ToInt32(idUsuario));
            if (usuario != null)
            {
                return usuario;
            }
            else
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al obtener usuario.');</script>");
                return null;
            }
        }

        public void modificarUsuario(String idUsuario,String idRol, string nombre, string correo, string nick, string contraseña)
        {
            try
            {
                if (nombre != "" & correo != "" & nick != "" & contraseña != "")
                {
                    usuarioDAO.modificarUsuario(Convert.ToInt32(idUsuario), Convert.ToInt32(idRol), nombre, correo, nick, contraseña);
                    HttpContext.Current.Response.Redirect("../Usuario/AdministrarUsuarios.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('No se permiten espacios en blanco!');</script>");
                }
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al modificar usuario.');</script>");
            }
        }

        public void eliminarUsuario(String idUsuario)
        {
            try
            {
                usuarioDAO.eliminarUsuario(Convert.ToInt32(idUsuario));
                HttpContext.Current.Response.Redirect("../Usuario/AdministrarUsuarios.aspx", true);
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al eliminar usuario.');</script>");
            }
        }
    }
}