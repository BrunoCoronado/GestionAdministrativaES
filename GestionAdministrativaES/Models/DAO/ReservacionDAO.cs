using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models.DAO
{
    public class ReservacionDAO
    {
        public Boolean verificarDisponibilidadReservacion(int idSalon, string fechaInicio, string fechaFin, string horaInicio, string horaFin)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM reservacion WHERE idSalon = "+idSalon+" AND fechaInicial = '"+fechaInicio+"' AND fechaFinal = '"+fechaFin+"' AND horaInicio = '"+horaInicio+"' AND horaFinal = '"+horaFin+"';", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
            catch 
            {
                connection.Close();
                return false;
            }
        }

        public void insertarReservacion(int idUsuario, int idSalon, int idOperador, int estado, string actividad, string horaInicio, string horaFinal, string periodo, string fechaInicial, string fechaFinal)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO reservacion VALUES(" + idUsuario + "," + idSalon + "," + idOperador + "," + estado + ",NULL,'" + actividad + "','" + horaInicio + "','" + horaFinal + "','" + periodo + "','" + fechaInicial + "','" + fechaFinal + "',NULL);", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }

        public int insertarReservacion(int idUsuario, int idSalon, int idOperador, int estado, string actividad, string horaInicio, string horaFinal, string periodo, string fechaInicial, string fechaFinal, string carta)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO reservacion VALUES(" + idUsuario + "," + idSalon + "," + idOperador + "," + estado + ",'"+carta+"','" + actividad + "','" + horaInicio + "','" + horaFinal + "','" + periodo + "','" + fechaInicial + "','" + fechaFinal + "',NULL);", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("SELECT SCOPE_IDENTITY();", connection);
                int response = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return response;
            }
            catch
            {
                connection.Close();
                return 0;
            }
        }

        public Reservacion buscarReservacion(int idReservacion)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM reservacion WHERE idReservacion = " + idReservacion + ";", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Reservacion reservacion = new Reservacion(reader.GetInt32(0),reader.GetInt32(1),reader.GetInt32(2),reader.GetInt32(3),reader.GetInt32(4),reader.GetString(6),reader.GetString(7),reader.GetString(8),reader.GetString(9),reader.GetString(10),reader.GetString(11));
                    if (reader.GetValue(5) != null)
                    {
                        reservacion.carta = reader.GetString(6);
                    }
                    connection.Close();
                    return reservacion;
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

        public void modificarReservacion(int idReservacion, int idUsuario, int idSalon, int estado, string periodo, string actividad, string horaInicio, string horaFinal, string fechaInicial, string fechaFinal)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE reservacion SET idUsuario = " + idUsuario + ", idSalon = " + idSalon + ", estado = " + estado + ", periodo = '" + periodo + "', horaInicio = '"+horaInicio+"' , horaFinal = '"+horaFinal+"', actividad = '"+actividad+"', fechaInicial = '"+fechaInicial+"', fechaFinal = '"+fechaFinal+"'  WHERE idReservacion = " + idReservacion + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public void eliminarReservacion(int idReservacion)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM reservacion WHERE idReservacion = " + idReservacion + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        } 

        public int insertarCarta(int idReservacion, string carta)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE reservacion SET carta = '"+carta+"' WHERE idReservacion = "+idReservacion+";", connection);
                int response = command.ExecuteNonQuery();
                connection.Close();
                return response;
            }
            catch
            {
                connection.Close();
                return 0;
            }
        }

        public void insertarCodigoQR(int idReservacion, string codigoQR)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE reservacion SET codigoQR = '" + codigoQR + "' WHERE idReservacion = " + idReservacion + ";", connection);
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