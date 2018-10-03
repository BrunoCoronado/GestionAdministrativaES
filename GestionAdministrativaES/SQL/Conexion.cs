using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace GestionAdministrativaES.SQL
{
    public class Conexion
    {
        private static SqlConnection connection = new SqlConnection("Data source=TREXT-PC;Initial Catalog=db_gestion_administrativa_escuela_de_sistema;Integrated Security=true");
        
        public static SqlConnection getConnection()
        {
            return connection;
        }

        public SqlCommand executeCommand(string command)
        {
            SqlCommand sqlCommand = new SqlCommand(command, connection);
            return sqlCommand;
        }
    }
}