using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace GestionAdministrativaES.SQL
{
    public class Conexion
    {
        //Conexion a la base de datos
        private static SqlConnection connection = new SqlConnection("Data source=TREXT-PC;Initial Catalog=db_gestion_administrativa_escuela_de_sistema;Integrated Security=true");

        //para recibir la conexion de la base de datos
        public static SqlConnection getConnection()
        {
            return connection;
        }

        //para SQLCommands
        public SqlCommand executeCommand(string command)
        {
            SqlCommand sqlCommand = new SqlCommand(command, connection);
            return sqlCommand;
        }
    }
}