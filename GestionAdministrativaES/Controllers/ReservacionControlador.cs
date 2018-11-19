using GestionAdministrativaES.Models;
using GestionAdministrativaES.Models.DAO;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Controllers
{
    public class ReservacionControlador
    {
        ReservacionDAO reservacionDAO = new ReservacionDAO();

        public void verificarDisponibilidadReservacion(string idSalon, string fechaInicio, string fechaFin, string horaInicio, string horaFin)
        {
            if (fechaInicio != "" & fechaFin != "" & horaInicio != "" & horaFin != "")
            {
                if (reservacionDAO.verificarDisponibilidadReservacion(Convert.ToInt32(idSalon), fechaInicio, fechaFin, horaInicio, horaFin))
                {
                    HttpContext.Current.Response.Write("<script>window.alert('Espacio solicitado disponible.');</script>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('Espacio solicitado no disponible.');</script>");
                }
            }
            else
            {
                HttpContext.Current.Response.Write("<script>window.alert('No se permiten campos en blanco.');</script>");
            }
        }

        public void insertarReservacion(string idUsuario, string idSalon, string idOperador, string periodo, string actividad, string horaInicio, string horaFin, string fechaInicio, string fechaFin, string carta)
        {
            try
            {
                if (fechaInicio != "" & fechaFin != "" & horaInicio != "" & horaFin != "")
                {
                    if (carta != "")
                    {
                        if (reservacionDAO.verificarDisponibilidadReservacion(Convert.ToInt32(idSalon), fechaInicio, fechaFin, horaInicio, horaFin))
                        {
                            int idReservacion = reservacionDAO.insertarReservacion(Convert.ToInt32(idUsuario), Convert.ToInt32(idSalon), Convert.ToInt32(idOperador), 0, actividad, horaInicio, horaFin, periodo, fechaInicio, fechaFin, carta);
                            if (idReservacion > 0)
                            {
                                reservacionDAO.insertarCodigoQR(Convert.ToInt32(idReservacion), generarCodigoQR(Convert.ToString(idReservacion), fechaInicio, horaInicio, horaFin));
                            }
                        }
                        else
                        {
                            HttpContext.Current.Response.Write("<script>window.alert('Espacio solicitado no disponible.');</script>");
                        }
                    }
                    else
                    {
                        if (reservacionDAO.verificarDisponibilidadReservacion(Convert.ToInt32(idSalon), fechaInicio, fechaFin, horaInicio, horaFin))
                        {
                            reservacionDAO.insertarReservacion(Convert.ToInt32(idUsuario), Convert.ToInt32(idSalon), Convert.ToInt32(idOperador), 0, actividad, horaInicio, horaFin, periodo, fechaInicio, fechaFin);
                        }
                        else
                        {
                            HttpContext.Current.Response.Write("<script>window.alert('Espacio solicitado no disponible.');</script>");
                        }
                    }
                    HttpContext.Current.Response.Redirect("AdministrarReservaciones.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('No se permiten campos en blanco.');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al insertar reservacion.');</script>");
            }
        }

        public Reservacion buscarReservacion(string idReservacion) {
            Reservacion reservacion = reservacionDAO.buscarReservacion(Convert.ToInt32(idReservacion));
            if (reservacion != null)
            {
                return reservacion;
            }
            else
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al obtener reservacion.');</script>");
                return null;
            }
        }

        public Reservacion buscarReservacionCuestionario(string idReservacion)
        {
            try
            {
                return reservacionDAO.buscarReservacionCuestionario(Convert.ToInt32(idReservacion));
            }
            catch
            {
                return null;
            }
        }

        public void modificarReservacion(string idReservacion, string idUsuario, string idSalon, string estado, string periodo, string actividad, string horaInicio, string horaFinal, string fechaInicial, string fechaFinal)
        {
            try
            {
                if (fechaInicial != "" & fechaFinal != "" & horaInicio != "" & horaFinal != "")
                {
                    reservacionDAO.modificarReservacion(Convert.ToInt32(idReservacion), Convert.ToInt32(idUsuario), Convert.ToInt32(idSalon), Convert.ToInt32(estado), periodo, actividad, horaInicio, horaFinal, fechaInicial, fechaFinal);
                    HttpContext.Current.Response.Redirect("AdministrarReservaciones.aspx", true);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('Espacio solicitado no disponible.');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al modificar reservacion.');</script>");
            }
        }

        public void eliminarReservacion(string idReservacion)
        {
            try
            {
                reservacionDAO.eliminarReservacion(Convert.ToInt32(idReservacion));
                HttpContext.Current.Response.Redirect("AdministrarReservaciones.aspx", true);
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al eliminar reservacion.');</script>");
            }
        }

        public void agregarCartaDeReservacion(string idReservacion, string carta)
        {
            try
            {
                if (carta != "")
                {
                    if (reservacionDAO.insertarCarta(Convert.ToInt32(idReservacion), carta) > 0)
                    {
                        Reservacion reservacion = reservacionDAO.buscarReservacion(Convert.ToInt32(idReservacion));
                        reservacionDAO.insertarCodigoQR(Convert.ToInt32(idReservacion), generarCodigoQR(Convert.ToString(idReservacion), reservacion.FechaInicial, reservacion.HoraInicio, reservacion.HoraFinal));
                    }
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('Seleccione una carta');</script>");
                }
                HttpContext.Current.Response.Redirect("AdministrarReservaciones.aspx", true);
            }
            catch
            {

            }
        }

        private string generarCodigoQR(string idReservacion, string fecha, string horaInicio, string horaFin)
        {
            try
            {
                QrEncoder qrEnconder = new QrEncoder(ErrorCorrectionLevel.H);
                QrCode qrCode = qrEnconder.Encode(idReservacion + ":" + fecha + ":" + horaInicio + ":" + horaFin);
                string name = "codigoQR_" + idReservacion + "_" + fecha + ".png";
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\codigosQR\\" + name + "";
                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(200, QuietZoneModules.Two), Brushes.Black, Brushes.White);
                FileStream fileStream = new FileStream(path, FileMode.Create);
                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, fileStream);
                fileStream.Close();
                return name;
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al generar codigoQR');</script>");
                return null;
            }
        }

        public List<Reservacion> listaReservaciones()
        {
            try
            {
                return reservacionDAO.listaReservaciones();
            }
            catch
            {
                return null;
            }
        }

        public List<Reservacion> listaActividades()
        {
            try
            {
                return reservacionDAO.listaActividades();
            }
            catch
            {
                return null;
            }
        }

        public string codigoQRReservacion(string idReservacion)
        {
            try
            {
                return reservacionDAO.codigoQRReservacion(Convert.ToInt32(idReservacion));
            }
            catch
            {
                return "";
            }
        }

        public string presentacionReservacion(string idReservacion)
        {
            try
            {
                return reservacionDAO.presentacionReservacion(Convert.ToInt32(idReservacion));
            }
            catch
            {
                return "";
            }
        }

        public void agregarPresentacion(string idReservacion, string presentacion)
        {
            try
            {
                if (presentacion != "")
                {
                    reservacionDAO.insertarPresentacion(Convert.ToInt32(idReservacion), presentacion);
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('Seleccione una presentacion');</script>");
                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error');</script>");
            }
        }

        public int agregarCuestionario(string idReservacion)
        {
            try
            {
                return reservacionDAO.crearCuestionario(Convert.ToInt32(idReservacion));
            }
            catch
            {
                return 0;
            }
        }

        public Pregunta agregarPregunta(string idCuestionario, string pregunta)
        {
            try
            {
                return reservacionDAO.agregarPregunta(Convert.ToInt32(idCuestionario), pregunta);
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error');</script>");
                return null;
            }
        }

        public List<Pregunta> preguntasCuestionario(int idCuestionario)
        {
            try
            {
                return reservacionDAO.preguntasDelCuestionario(idCuestionario);
            }
            catch
            {
                return null;
            }
        }

        public List<Pregunta> preguntas(string idReservacion)
        {
            try
            {
                return reservacionDAO.preguntasCuestionario(Convert.ToInt32(idReservacion));
            }
            catch
            {
                return null;
            }
        }
    }
}