using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace GestionAdministrativaES.Models
{
    public class Usuario
    {
        private int _IdUsuario;
        private Rol _Rol;
        private string _Nombre;
        private string _Correo;
        private string _Nick;
        private string _Contraseña;

        public string nick { get => _Nick; set => _Nick = value; }
        public string contraseña { get => _Contraseña; set => _Contraseña = value; }
        public int idUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public Rol rol { get => _Rol; set => _Rol = value; }
        public string nombre { get => _Nombre; set => _Nombre = value; }
        public string correo { get => _Correo; set => _Correo = value; }

        public Usuario(int IdUsuario, Rol rol, string Nombre, string Correo, string Nick, string Contraseña)
        {
            _IdUsuario = IdUsuario;
            _Rol = rol;
            _Nombre = Nombre;
            _Correo = Correo;
            _Nick = Nick;
            _Contraseña = Contraseña;
        }

        public Usuario() { }
    }
}