using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models.DAO
{
    public class ReservacionDAO
    {
        public Boolean verificarDisponibilidadReservacion(int idSalon, string fechaInicio, string fechaFin, string horaInicio, string horaFin)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM reservacion WHERE idSalon = "+idSalon+" AND fechaInicial = '"+fechaInicio+"' AND fechaFinal = '"+fechaFin+"' AND horaInicio = '"+horaInicio+"' AND horaFinal = '"+horaFin+"';", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
            catch 
            {
                connection.Close();
                return false;
            }
        }

        public void insertarReservacion(int idUsuario, int idSalon, int idOperador, int estado, string actividad, string horaInicio, string horaFinal, string periodo, string fechaInicial, string fechaFinal)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO reservacion VALUES(" + idUsuario + "," + idSalon + "," + idOperador + "," + estado + ",NULL,'" + actividad + "','" + horaInicio + "','" + horaFinal + "','" + periodo + "','" + fechaInicial + "','" + fechaFinal + "',NULL,NULL,NULL,0);", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
            }
        }

        public int insertarReservacion(int idUsuario, int idSalon, int idOperador, int estado, string actividad, string horaInicio, string horaFinal, string periodo, string fechaInicial, string fechaFinal, string carta)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO reservacion VALUES(" + idUsuario + "," + idSalon + "," + idOperador + "," + estado + ",'"+carta+"','" + actividad + "','" + horaInicio + "','" + horaFinal + "','" + periodo + "','" + fechaInicial + "','" + fechaFinal + "',NULL,NULL,NULL,0);", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("SELECT SCOPE_IDENTITY();", connection);
                int response = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return response;
            }
            catch
            {
                connection.Close();
                return 0;
            }
        }

        public Reservacion buscarReservacion(int idReservacion)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT r.idReservacion, u.idUsuario, u.nick, s.idSalon, s.ubicacion, o.idUsuario, o.nick, r.estado, r.actividad, r.periodo, r.horaInicio, r.horaFinal, r.fechaInicial, r.fechaFinal, r.carta, r.codigoQR FROM reservacion r INNER JOIN salon s ON r.idSalon = s.idSalon INNER JOIN usuario u ON r.idUsuario = u.idRol INNER JOIN usuario o ON r.idOperador = o.idUsuario WHERE idReservacion = " + idReservacion+";", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Reservacion reservacion = new Reservacion(reader.GetInt32(0), new Usuario(reader.GetInt32(1), reader.GetString(2)), new Salon(reader.GetInt32(3), reader.GetString(4)), new Usuario(reader.GetInt32(5), reader.GetString(6)), reader.GetInt32(7), reader.GetString(8),reader.GetString(10), reader.GetString(11), reader.GetString(9), reader.GetString(12), reader.GetString(13));
                    try
                    {
                        reservacion.carta = reader.GetString(14);
                        reservacion.CodigoQR = reader.GetString(15);
                    }
                    catch
                    {

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
            catch 
            {
                connection.Close();
                return null;
            }
        }

        public Reservacion buscarReservacionCuestionario(int idReservacion)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT r.idReservacion, r.cuestionario FROM reservacion r INNER JOIN salon s ON r.idSalon = s.idSalon INNER JOIN usuario u ON r.idUsuario = u.idRol INNER JOIN usuario o ON r.idOperador = o.idUsuario WHERE idReservacion = " + idReservacion + ";", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Reservacion reservacion = new Reservacion();
                    reservacion.idReservacion = reader.GetInt32(0);
                    try
                    {
                        reservacion.cuestionario = reader.GetInt32(1);
                    }
                    catch
                    {

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
            catch
            {
                connection.Close();
                return null;
            }
        }

        public void modificarReservacion(int idReservacion, int idUsuario, int idSalon, int estado, string periodo, string actividad, string horaInicio, string horaFinal, string fechaInicial, string fechaFinal)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE reservacion SET idUsuario = " + idUsuario + ", idSalon = " + idSalon + ", estado = " + estado + ", periodo = '" + periodo + "', horaInicio = '"+horaInicio+"' , horaFinal = '"+horaFinal+"', actividad = '"+actividad+"', fechaInicial = '"+fechaInicial+"', fechaFinal = '"+fechaFinal+"'  WHERE idReservacion = " + idReservacion + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
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
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        } 

        public int insertarCarta(int idReservacion, string carta)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE reservacion SET carta = '"+carta+"' WHERE idReservacion = "+idReservacion+";", connection);
                int response = command.ExecuteNonQuery();
                connection.Close();
                return response;
            }
            catch
            {
                connection.Close();
                return 0;
            }
        }

        public void insertarCodigoQR(int idReservacion, string codigoQR)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE reservacion SET estado = 1, codigoQR = '" + codigoQR + "' WHERE idReservacion = " + idReservacion + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public List<Reservacion> listaReservaciones()
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            List<Reservacion> reservaciones = new List<Reservacion>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT r.idReservacion, u.idUsuario, u.nick, s.idSalon, s.ubicacion, o.idUsuario, o.nick, r.estado, r.actividad, r.periodo, r.horaInicio, r.horaFinal, r.fechaInicial, r.fechaFinal, r.carta, r.codigoQR FROM reservacion r INNER JOIN salon s ON r.idSalon = s.idSalon INNER JOIN usuario u ON r.idUsuario = u.idUsuario INNER JOIN usuario o ON r.idOperador = o.idUsuario;", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Reservacion reservacion = new Reservacion(reader.GetInt32(0), new Usuario(reader.GetInt32(1), reader.GetString(2)), new Salon(reader.GetInt32(3), reader.GetString(4)), new Usuario(reader.GetInt32(5), reader.GetString(6)), reader.GetInt32(7), reader.GetString(8), reader.GetString(10), reader.GetString(11), reader.GetString(9), reader.GetString(12), reader.GetString(13));
                        try
                        {
                            reservacion.carta = reader.GetString(14);
                            reservacion.CodigoQR = reader.GetString(15);
                        }
                        catch
                        {

                        }
                        reservaciones.Add(reservacion);
                    }
                    connection.Close();
                    return reservaciones;
                }
                else
                {
                    connection.Close();
                    return reservaciones;
                }
            }
            catch
            {
                connection.Close();
                return reservaciones;
            }
        }

        public List<Reservacion> listaActividades()
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            List<Reservacion> reservaciones = new List<Reservacion>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT u.nick, s.ubicacion, r.actividad, r.horaInicio, r.fechaInicial, r.cupo, r.estado, r.idReservacion FROM reservacion r INNER JOIN salon s ON r.idSalon = s.idSalon INNER JOIN usuario u ON r.idUsuario = u.idUsuario INNER JOIN usuario o ON r.idOperador = o.idUsuario WHERE r.estado = 1;", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        reservaciones.Add(new Reservacion(new Usuario(reader.GetString(0)), new Salon(reader.GetString(1)), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7)));
                    }
                    connection.Close();
                    return reservaciones;
                }
                else
                {
                    connection.Close();
                    return reservaciones;
                }
            }
            catch
            {
                connection.Close();
                return reservaciones;
            }
        }

        public string codigoQRReservacion(int idReservacion)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT codigoQR FROM reservacion WHERE idReservacion = "+idReservacion+";", connection);
                string codigo = command.ExecuteScalar().ToString();
                connection.Close();
                return codigo;
            }
            catch
            {
                connection.Close();
                return "";
            }
        }

        public string presentacionReservacion(int idReservacion)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT presentacion FROM reservacion WHERE idReservacion = " + idReservacion + ";", connection);
                string presentacion = command.ExecuteScalar().ToString();
                connection.Close();
                return presentacion;
            }
            catch
            {
                connection.Close();
                return "";
            }
        }

        public void insertarPresentacion(int idReservacion ,string presentacion)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE reservacion SET presentacion = '" + presentacion + "' WHERE idReservacion = " + idReservacion + ";", connection);
                int response = command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
            }
        }

        public int crearCuestionario(int idReservacion)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO cuestionario VALUES("+idReservacion+");", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("SELECT SCOPE_IDENTITY();", connection);
                int idCuestionario = Convert.ToInt32(command.ExecuteScalar());
                command = new SqlCommand("UPDATE reservacion SET cuestionario = " + idCuestionario + " WHERE idReservacion = " + idReservacion + ";", connection);
                command.ExecuteNonQuery();
                connection.Close();
                return idCuestionario;
            }
            catch
            {
                connection.Close();
                return 0;
            }
        }

        public Pregunta agregarPregunta(int idCuestionario, string pregunta)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO pregunta VALUES(" + idCuestionario + ", '"+pregunta+"');", connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("SELECT SCOPE_IDENTITY();", connection);
                int idPregunta = Convert.ToInt32(command.ExecuteScalar());
                Pregunta prg = new Pregunta(idPregunta, idCuestionario, pregunta);
                connection.Close();
                return prg;
            }
            catch
            {
                connection.Close();
                return null;
            }

        }

        public List<Pregunta> preguntasDelCuestionario(int idCuestionario)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            List<Pregunta> preguntas = new List<Pregunta>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM pregunta WHERE idCuestionario = " + idCuestionario + ";", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        preguntas.Add(new Pregunta(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
                    }
                }
                connection.Close();
                return preguntas;
            }
            catch
            {
                connection.Close();
                return null;
            }
        }

        public List<Pregunta> preguntasCuestionario(int idReservacion)
        {
            SqlConnection connection = SQL.Conexion.getConnection();
            List<Pregunta> preguntas = new List<Pregunta>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(" SELECT cuestionario FROM reservacion WHERE idReservacion = "+idReservacion+";", connection);
                int idCuestionario = Convert.ToInt32(command.ExecuteScalar());
                command = new SqlCommand("SELECT * FROM pregunta WHERE idCuestionario = " + idCuestionario + ";", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        preguntas.Add(new Pregunta(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
                    }
                }
                connection.Close();
                return preguntas;
            }
            catch
            {
                connection.Close();
                return null;
            }
        }
    }
}