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
    }
}