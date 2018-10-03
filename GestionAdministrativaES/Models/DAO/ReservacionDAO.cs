using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models.DAO
{
    public class ReservacionDAO
    {
        public void insertarReservacion(int idUsuario, int idSalon, int idOperador, int estado, string carta, string periodo)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO reservacion VALUES(" + idUsuario + "," + idSalon + "," + idOperador + "," + estado + ",NULL,'" + periodo + "');", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
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
                    Reservacion reservacion = new Reservacion(reader.GetInt32(0),reader.GetInt32(1),reader.GetInt32(2),reader.GetInt32(3),reader.GetInt32(4),reader.GetString(6));
                    if (reader.GetValue(5) != null)
                    {
                        reservacion.carta = reader.GetString(5);
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
            catch (Exception e)
            {
                connection.Close();
                return null;
            }
        }

        public void modificarReservacion(int idReservacion, int idUsuario, int idSalon, int idOperador, int estado, string carta, string periodo)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE reservacion SET idUsuario = " + idUsuario + ", idSalon = " + idSalon + ", idOperador = " + idOperador + ", estado = " + estado + ", carta = '" + carta + "', periodo = '" + periodo + "' WHERE idReservacion = " + idReservacion + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
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
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        } 

        public void insertarCarta(int idReservacion, string carta)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("", connection);
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        }
    }
}