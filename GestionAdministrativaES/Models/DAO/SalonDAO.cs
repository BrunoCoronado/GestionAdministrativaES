using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace GestionAdministrativaES.Models.DAO
{
    public class SalonDAO
    {
        public void insertarSalon(String ubicacion, int capacidad) {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO salon VALUES ('" + ubicacion + "'," + capacidad + ",0)", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        }

        public void eliminarSalon(int idSalon) {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM salon WHERE idSalon = "+idSalon+";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        }

        public Salon buscarSalon(int idSalon)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM salon where idSalon = "+idSalon+";", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Salon salon= new Salon(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                    
                    connection.Close();
                    return salon;
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

        public void modificarSalon(int idSalon,String ubicacion, int capacidad)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE salon SET ubicacion = '"+ubicacion+"', capacidad = "+capacidad+" WHERE idSalon = "+idSalon+";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        }
        
        public void listarSalones() { }
    }
}