using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class UsuarioDAO
    {
        public Usuario iniciarSesion(string nick, string contraseña)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT u.idUsuario,u.nombre,u.correo,u.nick,u.contraseña,r.idRol,r.nombre as rol FROM usuario u INNER JOIN rol r ON u.idRol = r.idRol WHERE u.nick = '" + nick + "' AND u.contraseña = '" + contraseña + "'", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Usuario usuario = new Usuario();
                    while (reader.Read())
                    {
                        Rol rol = new Rol(reader.GetInt32(5), reader.GetString(6));
                        usuario = new Usuario(reader.GetInt32(0), rol, reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    }
                    connection.Close();
                    return usuario;
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                connection.Close();
                return null;
            }
        }

        public void registrarUsuario() { }
        public void recuperarContraseña() { }
        public void modificarUsuario() { }
        public void eliminarUsuario() { }
        public void verUsuarios() { }
    }
}