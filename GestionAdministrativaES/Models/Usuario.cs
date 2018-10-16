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
        private int _Carnet;
        private int _Telefono;
        private string _PalabraClave;

        public string nick { get => _Nick; set => _Nick = value; }
        public string contraseña { get => _Contraseña; set => _Contraseña = value; }
        public int idUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public Rol rol { get => _Rol; set => _Rol = value; }
        public string nombre { get => _Nombre; set => _Nombre = value; }
        public string correo { get => _Correo; set => _Correo = value; }
        public int Carnet { get => _Carnet; set => _Carnet = value; }
        public int Telefono { get => _Telefono; set => _Telefono = value; }
        public string PalabraClave { get => _PalabraClave; set => _PalabraClave = value; }

        public Usuario(int IdUsuario, Rol Rol, string Nombre, string Correo, string Nick, string Contraseña, int Carnet, int Telefono, string PalabraClave)
        {
            _IdUsuario = IdUsuario;
            _Rol = Rol;
            _Nombre = Nombre;
            _Correo = Correo;
            _Nick = Nick;
            _Contraseña = Contraseña;
            _Carnet = Carnet;
            _Telefono = Telefono;
            _PalabraClave = PalabraClave;
        }

        public Usuario() { }

        public Usuario(string Nick)
        {
            _Nick = Nick;
        }

        public Usuario(int IdUsuario, string Nick)
        {
            _IdUsuario = IdUsuario;
            _Nick = Nick;
        }

        public Usuario(Rol Rol, string Nombre, string Correo, string Nick, string Contraseña, int Carnet, int Telefono, string PalabraClave)
        {
            _Rol = Rol;
            _Nombre = Nombre;
            _Correo = Correo;
            _Nick = Nick;
            _Contraseña = Contraseña;
            _Carnet = Carnet;
            _Telefono = Telefono;
            _PalabraClave = PalabraClave;
        }
    }
}