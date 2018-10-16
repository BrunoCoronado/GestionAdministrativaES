using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class Rol
    {
        private int _idRol;
        private string _nombre;

        public int idRol { get => _idRol; set => _idRol = value; }
        public string nombre { get => _nombre; set => _nombre = value; }

        public Rol(int idRol, string nombre)
        {
            _idRol = idRol;
            _nombre = nombre;
        }

        public Rol()
        {
        }
    }
}