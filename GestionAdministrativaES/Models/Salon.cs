using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class Salon
    {
        private int _IdSalon;
        private string _Ubicacion;
        private int _Capacidad;
        private int _Estado;

        public int idSalon { get => _IdSalon; set => _IdSalon = value; }
        public string ubicacion { get => _Ubicacion; set => _Ubicacion = value; }
        public int capacidad { get => _Capacidad; set => _Capacidad = value; }
        public int estado { get => _Estado; set => _Estado = value; }

        public Salon()
        {
        }

        public Salon(int IdSalon, string Ubicacion, int Capacidad, int Estado)
        {
            _IdSalon = IdSalon;
            _Ubicacion = Ubicacion;
            _Capacidad = Capacidad;
            _Estado = Estado;
        }
    }
}