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
    }
}