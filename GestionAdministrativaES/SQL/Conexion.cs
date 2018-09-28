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
        private static SqlConnection conexion = new SqlConnection("Data source=TREXT-PC;Initial Catalog=db_gestion_administrativa_escuela_de_sistema;Integrated Security=true");

        //para recibir la conexion de la base de datos
        public static SqlConnection recibirConexion()
        {
            return conexion;
        }

        //para SQLCommands
        public SqlCommand agregarComando(string instrucciones)
        {
            SqlCommand comando = new SqlCommand(instrucciones, conexion);
            return comando;
        }
    }
}