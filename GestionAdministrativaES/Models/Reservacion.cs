using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class Reservacion
    {
        private int _IdReservacion;
        private int _IdUsuario;
        private int _IdSalon;
        private int _IdOperador;
        private int _Estado;
        private string _Carta;
        private string _Periodo;

        public int idReservacion { get => _IdReservacion; set => _IdReservacion = value; }
        public int idUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public int idSalon { get => _IdSalon; set => _IdSalon = value; }
        public int idOperador { get => _IdOperador; set => _IdOperador = value; }
        public int estado { get => _Estado; set => _Estado = value; }
        public string carta { get => _Carta; set => _Carta = value; }
        public string periodo { get => _Periodo; set => _Periodo = value; }

        public Reservacion(int IdReservacion, int IdUsuario, int IdSalon, int IdOperador, int Estado, string Carta, string Periodo)
        {
            _IdReservacion = IdReservacion;
            _IdUsuario = IdUsuario;
            _IdSalon = IdSalon;
            _IdOperador = IdOperador;
            _Estado = Estado;
            _Carta = Carta;
            _Periodo = Periodo;
        }

        public Reservacion(int IdReservacion, int IdUsuario, int IdSalon, int IdOperador, int Estado, string Periodo)
        {
            _IdReservacion = IdReservacion;
            _IdUsuario = IdUsuario;
            _IdSalon = IdSalon;
            _IdOperador = IdOperador;
            _Estado = Estado;
            _Periodo = Periodo;
        }
    }
}