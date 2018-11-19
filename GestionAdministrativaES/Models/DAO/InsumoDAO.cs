using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models.DAO
{
    public class InsumoDAO
    {
        public List<Insumo> listaDeInsumos()
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            List<Insumo> insumos = new List<Insumo>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT i.idInsumo, i.idTipoInsumo, t.nombre, i.nombre, i.estado FROM insumo i INNER JOIN tipoInsumo t ON i.idTipoInsumo = t.idTipoInsumo;", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        insumos.Add(new Insumo(reader.GetInt32(0), new TipoInsumo(reader.GetInt32(1), reader.GetString(2)), reader.GetString(3), reader.GetInt32(4)));
                    }
                }
                connection.Close();
                return insumos;
            }
            catch
            {
                connection.Close();
                return insumos;
            }
        }

        public void insertarInsumo(int idTipoInsumo, string nombre, int estado)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO insumo VALUES(" + idTipoInsumo + ", '" + nombre + "', " + estado + ");", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public void eliminarInsumo(int idInsumo)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM insumo WHERE idInsumo = " + idInsumo + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public void modificarInsumo(int idInsumo, string nombre, int idTipoInsumo)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE insumo SET nombre = '" + nombre + "', idTipoInsumo = " + idTipoInsumo + " WHERE idInsumo = " + idInsumo + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public Insumo buscarInsumo(int idInsumo)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM insumo i INNER JOIN tipoInsumo t ON i.idTipoInsumo = t.idTipoInsumo WHERE idInsumo = " + idInsumo + "; ", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Insumo insumo = new Insumo(reader.GetInt32(0), new TipoInsumo(reader.GetInt32(1), reader.GetString(5)), reader.GetString(2), reader.GetInt32(3));

                    connection.Close();
                    return insumo;
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

        public List<TipoInsumo> listaDeTipoDeInsumos()
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            List<TipoInsumo> tipoInsumos = new List<TipoInsumo>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM tipoInsumo;", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tipoInsumos.Add(new TipoInsumo(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
                connection.Close();
                return tipoInsumos;
            }
            catch
            {
                connection.Close();
                return tipoInsumos;
            }
        }

        public void insertarTipoInsumo(string nombre)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO tipoInsumo VALUES('" + nombre + "');", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public void eliminarTipoInsumo(int idTipoInsumo)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM tipoInsumo WHERE idTipoInsumo = " + idTipoInsumo + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public void modificarTipoInsumo(string nombre, int idTipoInsumo)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE tipoInsumo SET nombre = '" + nombre + "' WHERE idTipoInsumo = " + idTipoInsumo + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public TipoInsumo buscarTipoInsumo(int idTipoInsumo)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM tipoInsumo WHERE idTipoInsumo = " + idTipoInsumo + ";", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    TipoInsumo tipoInsumo = new TipoInsumo(reader.GetInt32(0), reader.GetString(1));
                    connection.Close();
                    return tipoInsumo;
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
    }
}