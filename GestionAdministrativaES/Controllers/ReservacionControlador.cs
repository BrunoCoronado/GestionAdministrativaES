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
            try
            {
                if (reservacionDAO.verificarDisponibilidadReservacion(Convert.ToInt32(idSalon),fechaInicio,fechaFin,horaInicio,horaFin))
                {
                    HttpContext.Current.Response.Write("<script>window.alert('Espacio solicitado disponible.');</script>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.alert('Espacio solicitado no disponible.');</script>");
                }
            }
            catch 
            {

            }
        }
        
        public void insertarReservacion(string idUsuario, string idSalon, string idOperador, string periodo, string actividad, string horaInicio, string horaFin, string fechaInicio, string fechaFin, string carta)
        {
            try
            {
                //falta validar campos
                if(carta != "")
                {
                    if (reservacionDAO.verificarDisponibilidadReservacion(Convert.ToInt32(idSalon), fechaInicio, fechaFin, horaInicio, horaFin))
                    {
                        int idReservacion = reservacionDAO.insertarReservacion(Convert.ToInt32(idUsuario), Convert.ToInt32(idSalon), Convert.ToInt32(idOperador), 0, actividad, horaInicio, horaFin, periodo, fechaInicio, fechaFin, carta);
                        if (idReservacion > 0)
                        {
                            reservacionDAO.insertarCodigoQR(Convert.ToInt32(idReservacion), generarCodigoQR(Convert.ToString(idReservacion),fechaInicio, horaInicio, horaFin));
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

        public void modificarReservacion(string idReservacion, string idUsuario, string idSalon, string estado, string periodo, string actividad, string horaInicio, string horaFinal, string fechaInicial, string fechaFinal)
        {
            try
            {
                reservacionDAO.modificarReservacion(Convert.ToInt32(idReservacion), Convert.ToInt32(idUsuario), Convert.ToInt32(idSalon), Convert.ToInt32(estado), periodo, actividad, horaInicio, horaFinal, fechaInicial, fechaFinal);
                HttpContext.Current.Response.Redirect("AdministrarReservaciones.aspx", true);
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
                        reservacionDAO.insertarCodigoQR(Convert.ToInt32(idReservacion), generarCodigoQR(Convert.ToString(idReservacion),reservacion.FechaInicial, reservacion.HoraInicio, reservacion.HoraFinal));
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
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\codigosQR\\codigoQR_"+idReservacion+"_"+fecha+".png";
                GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(200, QuietZoneModules.Two), Brushes.Black, Brushes.White);
                FileStream fileStream = new FileStream(path, FileMode.Create);
                renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, fileStream);
                fileStream.Close();
                return path;
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>window.alert('Error al generar codigoQR');</script>");
                return null;
            }
        }
    }
}