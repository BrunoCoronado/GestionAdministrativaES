using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class IncidenteSalon
    {
        private int _IdIncidenteSalon;
        private Usuario _Operador;
        private Salon _Salon;
        private Usuario _Usuario;
        private string _Descripcion;
        private string _Fecha;
        private int _Estado;

        public int IdIncidenteSalon { get => _IdIncidenteSalon; set => _IdIncidenteSalon = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Fecha { get => _Fecha; set => _Fecha = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public Usuario Operador { get => _Operador; set => _Operador = value; }
        public Salon Salon { get => _Salon; set => _Salon = value; }
        public Usuario Usuario { get => _Usuario; set => _Usuario = value; }

        public IncidenteSalon()
        {
        }

        public IncidenteSalon(int IdIncidenteSalon, Usuario Operador, Salon Salon, Usuario Usuario, string Descripcion, string Fecha, int Estado)
        {
            _IdIncidenteSalon = IdIncidenteSalon;
            _Operador = Operador;
            _Salon = Salon;
            _Usuario = Usuario;
            _Descripcion = Descripcion;
            _Fecha = Fecha;
            _Estado = Estado;
        }
    }
}