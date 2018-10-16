using ExcelDataReader;
using GestionAdministrativaES.Models;
using GestionAdministrativaES.Views;
using System;
using System.Collections.Generic;
using System.IO;
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
                Login.usuario = usuario;
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

        public void registrarUsuario(string idRol, string nombre, string correo, string nick, string contraseña, string carnet, string telefono, string palabraClave)
        {
            try
            {
                if (nombre != "" & correo != "" & nick != "" & contraseña != "" & correo != "" & carnet != "" & telefono != "" & palabraClave != "")
                {
                    if (usuarioDAO.registrarUsuario(Convert.ToInt32(idRol), nombre, correo, nick, contraseña, Convert.ToInt32(carnet), Convert.ToInt32(telefono), palabraClave)) 
                    {
                        HttpContext.Current.Response.Write("<script>window.alert('Estudiante registrado!');</script>");
                        HttpContext.Current.Response.Redirect("../Login.aspx", true);
                    }
                    else
                    {
                        HttpContext.Current.Response.Write("<script>window.alert('Error al registrarse');</script>");
                        HttpContext.Current.Response.Redirect("../Login.aspx", true);
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

        public void insertarUsuario(string idRol, string nombre, string correo, string nick, string contraseña, string carnet, string telefono, string palabraClave)
        {
            try
            {
                if (nombre != "" & correo != "" & nick != "" & contraseña != "" & correo != "" & carnet != "" & telefono != "" & palabraClave != "")
                {
                    usuarioDAO.insertarUsuario(Convert.ToInt32(idRol), nombre, correo, nick, contraseña, Convert.ToInt32(carnet), Convert.ToInt32(telefono), palabraClave);
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

        public Usuario buscarUsuario(string idUsuario)
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

        public void modificarUsuario(string idUsuario, string idRol, string nombre, string correo, string nick, string carnet, string telefono, string palabraClave)
        {
            try
            {
                if (nombre != "" & correo != "" & nick != "" &  correo != "" & carnet != "" & telefono != "" & palabraClave != "")
                {
                    usuarioDAO.modificarUsuario(Convert.ToInt32(idUsuario), Convert.ToInt32(idRol), nombre, correo, nick, Convert.ToInt32(carnet), Convert.ToInt32(telefono), palabraClave);
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

        public void eliminarUsuario(string idUsuario)
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

        public Usuario validarPalabraClave(string nick, string palabraClave)
        {
            try
            {
                if (palabraClave != "" & nick != "")
                {
                    Usuario usuario = usuarioDAO.validarPalabraClave(nick, palabraClave);
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
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('No se permiten espacios en blanco!');</script>");
                    return null;
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al obtener usuario.');</script>");
                return null;
            }
        }

        public void cambiarContraseña(string nick, string contraseña)
        {
            try
            {
                usuarioDAO.cambiarContraseña(nick,contraseña);
                HttpContext.Current.Response.Redirect("../Login.aspx", true);
            }
            catch (Exception ex)
            {

            }
        }

        public void cargaMasiva() { }

        public List<Usuario> listaDeUsuarios()
        {
            try
            {
                return usuarioDAO.listaDeUsuarios();
            }
            catch
            {
                return null;
            }
        }

        public void cargaMasivaUsuarios(string path)
        {
            
            FileStream stream = File.Open(path , FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            try
            {

                excelReader.Read();
                while (excelReader.Read())
                {
                    String idRol = "";
                    switch (excelReader.GetString(0))
                    {
                        case "Administrador":
                            idRol = "1";
                            break;
                        case "Operador del Sistema":
                            idRol = "2";
                            break;
                        case "Catedratico":
                            idRol = "3";
                            break;
                        case "Estudiante":
                            idRol = "4";
                            break;
                    }

                    insertarUsuarioCargaMasiva(idRol, excelReader.GetString(2), excelReader.GetString(4), excelReader.GetString(6), excelReader.GetString(7), Convert.ToString(excelReader.GetDouble(1)), Convert.ToString(excelReader.GetDouble(5)), excelReader.GetString(8));
                }
                excelReader.Close();
                HttpContext.Current.Response.Redirect("../Administrador/Usuario/AdministrarUsuarios.aspx", true);
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al leer archivo!');</script>");
                excelReader.Close();
            }
        }

        public void insertarUsuarioCargaMasiva(string idRol, string nombre, string correo, string nick, string contraseña, string carnet, string telefono, string palabraClave)
        {
            try
            {
                if (nombre != "" & correo != "" & nick != "" & contraseña != "" & correo != "" & carnet != "" & telefono != "" & palabraClave != "")
                {
                    usuarioDAO.insertarUsuario(Convert.ToInt32(idRol), nombre, correo, nick, contraseña, Convert.ToInt32(carnet), Convert.ToInt32(telefono), palabraClave);
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
    }
}