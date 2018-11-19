using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models.DAO
{
    public class MatriculaDAO
    {
        public void insertarMatricula(int idReservacion, int idUsuario, int cupo)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO matricula VALUES("+idReservacion+","+idUsuario+");", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("UPDATE reservacion SET cupo = "+(cupo+1)+" WHERE idReservacion = "+idReservacion+";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public int obtenerCupoActividad(int idReservacion)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT cupo FROM reservacion WHERE idReservacion = "+idReservacion+";", connection);
                int cupo = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return cupo;
            }
            catch
            {
                connection.Close();
                return 0;
            }
        }

        public List<Matricula> listarMatriculas(int idUsuario)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            List<Matricula> matriculas = new List<Matricula>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM matricula WHERE idUsuario = "+idUsuario+";", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        matriculas.Add(new Matricula(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }
                connection.Close();
                return matriculas;
            }
            catch
            {
                connection.Close();
                return matriculas;
            }
        }
    }
}