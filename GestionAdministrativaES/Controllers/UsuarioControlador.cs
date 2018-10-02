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

        public void buscarUsuario(String idUsuario)
        {
            usuarioDAO.buscarUsuario(Convert.ToInt32(idUsuario));
        }

        public void modificarUsuario(String idUsuario,String idRol, string nombre, string correo, string nick, string contraseña)
        {
            usuarioDAO.modificarUsuario(Convert.ToInt32(idUsuario),Convert.ToInt32(idRol), nombre,correo,nick,contraseña);
        }

        public void eliminarUsuario(String idUsuario)
        {
            usuarioDAO.eliminarUsuario(Convert.ToInt32(idUsuario));
        }
    }
}