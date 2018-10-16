using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models.DAO
{
    public class IncidenteSalonDAO
    {
        public void reportarIncidente(int idOperador, int idSalon, int idUsuario, string descripcion, string fecha, int estado)
        {
            SqlConnection connection = SQL.Conexion.getConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO incidenteSalon VALUES("+idOperador+","+idSalon+","+idUsuario+",'"+descripcion+"','"+fecha+"',"+estado+");",connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        }

        public void finalizarIncidente(int idIncidenteSalon, int estado)
        {
            SqlConnection connection = SQL.Conexion.getConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE incidenteSalon SET estado ="+estado+" WHERE idIncidenteSalon = "+idIncidenteSalon+";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
            }
        }

        public List<IncidenteSalon> obtenerIncidentesSalones()
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            List<IncidenteSalon> incidentes;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT i.idIncidenteSalon, i.descripcion, i.fecha, i.estado, s.ubicacion, u.nick, us.nick FROM incidenteSalon i INNER JOIN salon s ON i.idSalon = s.idSalon INNER JOIN usuario u ON i.idUsuario = u.idUsuario INNER JOIN usuario us ON i.idOperador = us.idUsuario;", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    incidentes = new List<IncidenteSalon>();
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario(reader.GetString(5));
                        Usuario operador = new Usuario(reader.GetString(6));
                        Salon salon = new Salon(reader.GetString(4));
                        IncidenteSalon incidente = new IncidenteSalon(reader.GetInt32(0),operador,salon,usuario,reader.GetString(1),reader.GetString(2),reader.GetInt32(3));
                        incidentes.Add(incidente);
                    }
                    connection.Close();
                    return incidentes;
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