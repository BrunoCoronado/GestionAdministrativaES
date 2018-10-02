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
                SqlCommand command = new SqlCommand("SELECT * FROM usuario u INNER JOIN rol r ON u.idRol = r.idRol WHERE u.nick = '" + nick + "' AND u.contraseña = '" + contraseña + "'", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Usuario usuario = new Usuario();
                    while (reader.Read())
                    {
                        Rol rol = new Rol(reader.GetInt32(6), reader.GetString(7));
                        usuario = new Usuario(reader.GetInt32(0), rol, reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
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
                connection.Close();
                return null;
            }
        }
        
        public Boolean registrarUsuario(int idRol, string nombre, string correo, string nick, string contraseña) {
            SqlConnection connection = new SqlConnection();
            try {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO usuario VALUES("+idRol+",'"+nombre+"','"+correo+"','"+nick+"','"+contraseña+"');", connection);
                if (command.ExecuteNonQuery() > 0)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
            catch(Exception e)
            {
                connection.Close();
                return false;
            }
        }

        //public void registrarUsuario(int idRol, string nombre, string correo, string nick, string contraseña)
        //{
        //    SqlConnection connection = new SqlConnection();
        //    try
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("INSERT INTO usuario VALUES(" + idRol + ",'" + nombre + "','" + correo + "','" + nick + "','" + contraseña + "');", connection);
        //        command.ExecuteNonQuery();
        //        connection.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        connection.Close();
        //    }
        //}

        public void eliminarUsuario(int idUsuario)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM usuario WHERE idUsuario = "+idUsuario+";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        }

        public Usuario buscarUsuario(int idUsuario)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM usuario u INNER JOIN rol r ON u.idRol = r.idRol WHERE u.idUsuario = " + idUsuario+";", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Rol rol = new Rol(reader.GetInt32(6), reader.GetString(7));
                    Usuario usuario = new Usuario(reader.GetInt32(0), rol, reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    return usuario;
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                connection.Close();
                return null;
            }
        }

        public void modificarUsuario(int idUsuario,int idRol, string nombre, string correo, string nick, string contraseña)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE usuario SET idRol = "+idRol+", nombre = '"+nombre+"', correo = '"+correo+"', nick='"+nick+"', contraseña = '"+contraseña+"' WHERE idUsuario = "+idUsuario+";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        }
        public void verUsuarios() { }
        public void recuperarContraseña() { }
    }
}