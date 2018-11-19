using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class Matricula
    {
        private int _idMatricula;
        private int _idReservacion;
        private int _idUsuario;

        public int IdMatricula { get => _idMatricula; set => _idMatricula = value; }
        public int IdReservacion { get => _idReservacion; set => _idReservacion = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }

        public Matricula(int idMatricula, int idReservacion, int idUsuario)
        {
            IdMatricula = idMatricula;
            IdReservacion = idReservacion;
            IdUsuario = idUsuario;
        }

        public Matricula()
        {
        }
    }
}