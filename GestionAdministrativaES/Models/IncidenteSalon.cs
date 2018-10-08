using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class IncidenteSalon
    {
        private int _IdIncidenteSalon;
        private int _IdOperador;
        private int _IdSalon;
        private int _IdUsuario;
        private string _Descripcion;
        private string _Fecha;
        private int _Estado;

        public int IdIncidenteSalon { get => _IdIncidenteSalon; set => _IdIncidenteSalon = value; }
        public int IdOperador { get => _IdOperador; set => _IdOperador = value; }
        public int IdSalon { get => _IdSalon; set => _IdSalon = value; }
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Fecha { get => _Fecha; set => _Fecha = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
    }
}