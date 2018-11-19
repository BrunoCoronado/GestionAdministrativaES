using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models.DAO
{
    public class IncidenteInsumoDAO
    {
        public void reportarIncidente(int idUsuario, int idInsumo, string fecha, int estado)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO incidenteInsumo VALUES("+idUsuario+","+idInsumo+",'"+fecha+"',"+estado+");", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("UPDATE insumo SET estado = 2 WHERE idInsumo = " + idInsumo + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public void finalizarIncidente(int idIncidenteInsumo, int estado)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE incidenteInsumo SET estado =" + estado + " WHERE idIncidenteInsumo = " + idIncidenteInsumo + ";", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("SELECT idInsumo FROM incidenteInsumo WHERE idIncidenteInsumo = " + idIncidenteInsumo + ";", connection);
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

        public List<IncidenteInsumo> obtenerIncidentesInsuos()
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            List<IncidenteInsumo> incidenteInsumos;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ii.idIncidenteInsumo, ii.idInsumo, i.nombre, u.nick, ii.fecha, ii.estado FROM incidenteInsumo ii INNER JOIN insumo i ON ii.idInsumo = i.idInsumo INNER JOIN usuario u ON ii.idUsuario = u.idUsuario;", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    incidenteInsumos = new List<IncidenteInsumo>();
                    while (reader.Read())
                    {
                        incidenteInsumos.Add(new IncidenteInsumo(reader.GetInt32(0), new Usuario(reader.GetString(3)), new Insumo(reader.GetInt32(1), reader.GetString(2)), reader.GetString(4), reader.GetInt32(5)));
                    }
                    connection.Close();
                    return incidenteInsumos;
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
    }
}