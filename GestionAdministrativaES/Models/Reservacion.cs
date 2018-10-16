using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class Reservacion
    {
        private int _IdReservacion;
        private Usuario _Usuario;
        private Salon _Salon;
        private Usuario _Operador;
        private int _Estado;
        private string _Carta;
        private string _Actividad;
        private string _HoraInicio;
        private string _HoraFinal;
        private string _Periodo;
        private string _FechaInicial;
        private string _FechaFinal;
        private string _CodigoQR;

        public int idReservacion { get => _IdReservacion; set => _IdReservacion = value; }
        public int estado { get => _Estado; set => _Estado = value; }
        public string carta { get => _Carta; set => _Carta = value; }
        public string Actividad { get => _Actividad; set => _Actividad = value; }
        public string HoraInicio { get => _HoraInicio; set => _HoraInicio = value; }
        public string HoraFinal { get => _HoraFinal; set => _HoraFinal = value; }
        public string Periodo { get => _Periodo; set => _Periodo = value; }
        public string FechaInicial { get => _FechaInicial; set => _FechaInicial = value; }
        public string FechaFinal { get => _FechaFinal; set => _FechaFinal = value; }
        public string CodigoQR { get => _CodigoQR; set => _CodigoQR = value; }
        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }
        public Salon Salon { get => _Salon; set => _Salon = value; }
        public Usuario Operador { get => _Operador; set => _Operador = value; }

        public Reservacion()
        {
        }

        public Reservacion(int IdReservacion, Usuario Usuario, Salon Salon, Usuario Operador, int Estado, string Actividad, string HoraInicio, string HoraFinal, string Periodo, string FechaInicial, string FechaFinal)
        {
            _IdReservacion = IdReservacion;
            _Usuario = Usuario;
            _Salon = Salon;
            _Operador = Operador;
            _Estado = Estado;
            _Actividad = Actividad;
            _HoraInicio = HoraInicio;
            _HoraFinal = HoraFinal;
            _Periodo = Periodo;
            _FechaInicial = FechaInicial;
            _FechaFinal = FechaFinal;
        }

        public Reservacion(int IdReservacion, Usuario Usuario, Salon Salon, Usuario Operador, int Estado, string carta, string Actividad, string HoraInicio, string HoraFinal, string Periodo, string FechaInicial, string FechaFinal)
        {
            _IdReservacion = IdReservacion;
            _Usuario = Usuario;
            _Salon = Salon;
            _Operador = Operador;
            _Estado = Estado;
            _Carta = carta;
            _Actividad = Actividad;
            _HoraInicio = HoraInicio;
            _HoraFinal = HoraFinal;
            _Periodo = Periodo;
            _FechaInicial = FechaInicial;
            _FechaFinal = FechaFinal;
        }
    }
}