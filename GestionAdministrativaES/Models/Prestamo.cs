using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class Prestamo
    {
        private int _idPrestamo;
        private Usuario _usuario;
        private Insumo _insumo;
        private Usuario _operador;
        private string _fecha;
        private int _estado;

        public int idPrestamo { get => _idPrestamo; set => _idPrestamo = value; }
        public Usuario usuario { get => _usuario; set => _usuario = value; }
        public Insumo insumo { get => _insumo; set => _insumo = value; }
        public Usuario operador { get => _operador; set => _operador = value; }
        public string fecha { get => _fecha; set => _fecha = value; }
        public int estado { get => _estado; set => _estado = value; }

        public Prestamo(int idPrestamo, Usuario usuario, Insumo insumo, Usuario operador, string fecha, int estado)
        {
            _idPrestamo = idPrestamo;
            _usuario = usuario;
            _insumo = insumo;
            _operador = operador;
            _fecha = fecha;
            _estado = estado;
        }

        public Prestamo()
        {
        }
    }
}