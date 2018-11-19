using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models.DAO
{
    public class PrestamoDAO
    {

        public void insertarPrestamo(int idUsuario, int idInsumo, int idOperador, string fecha, int estado)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO prestamoInsumo VALUES("+idUsuario+","+idInsumo+","+idOperador+",'"+fecha+"',"+estado+")", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("UPDATE insumo SET estado = 1 WHERE idInsumo = "+ idInsumo + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public void modificarPrestamo(int idPrestamo, int idUsuario, int idInsumo, string fecha)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE prestamoInsumo SET idUsuario = " + idUsuario + ", idInsumo = " + idInsumo + ", fechaPrestamo = '" + fecha + "' WHERE idPrestamoInsumo = " + idPrestamo + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public Prestamo buscarPrestamo(int idPrestamo)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT p.idPrestamoInsumo, u.nick, i.idInsumo, i.nombre, o.nick, p.fechaPrestamo, p.estado FROM prestamoInsumo p INNER JOIN usuario u ON p.idUsuario = u. idUsuario INNER JOIN insumo i ON P.idInsumo = I.idInsumo INNER JOIN usuario o ON p.idOperador = o.idUsuario WHERE idPrestamoInsumo = "+idPrestamo+";", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Prestamo prestamo = new Prestamo(reader.GetInt32(0), new Usuario(reader.GetString(1)), new Insumo(reader.GetInt32(2), reader.GetString(3)), new Usuario(reader.GetString(4)), reader.GetString(5), reader.GetInt32(6));
                    connection.Close();
                    return prestamo;
                }
                connection.Close();
                return null;
            }
            catch
            {
                connection.Close();
                return null;
            }
        }

        public void eliminarPrestamo(int idPrestamo)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM prestamoInsumo WHERE idPrestamoInsumo = " + idPrestamo + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public List<Prestamo> obtenerPrestamos()
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            List<Prestamo> prestamos = new List<Prestamo>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT p.idPrestamoInsumo, u.idUsuario, u.nick, i.idInsumo, i.nombre, o.nick, p.fechaPrestamo, p.estado FROM prestamoInsumo p INNER JOIN usuario u ON p.idUsuario = u. idUsuario INNER JOIN insumo i ON P.idInsumo = I.idInsumo INNER JOIN usuario o ON p.idOperador = o.idUsuario;", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) 
                {
                    while (reader.Read())
                    {
                        prestamos.Add(new Prestamo(reader.GetInt32(0), new Usuario(reader.GetInt32(1), reader.GetString(2)), new Insumo(reader.GetInt32(3), reader.GetString(4)), new Usuario(reader.GetString(5)), reader.GetString(6), reader.GetInt32(7)));
                    }
                    connection.Close();
                    return prestamos;
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }
            catch
            {
                connection.Close();
                return null;
            }
        }

        public void finalizarPrestamo(int idPrestamo)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE prestamoInsumo SET estado = 1 WHERE idPrestamoInsumo = "+idPrestamo+";", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("SELECT idInsumo FROM prestamoInsumo WHERE idPrestamoInsumo = " + idPrestamo + ";", connection);
                string id = command.ExecuteScalar().ToString();
                command = new SqlCommand("UPDATE insumo SET estado = 0 WHERE idInsumo = " + id + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }
    }
}