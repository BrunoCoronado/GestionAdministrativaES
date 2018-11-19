using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class Insumo
    {
        private int _idInsumo;
        private TipoInsumo _tipoInsumo;
        private string _nombre;
        private int _estado;

        public int idInsumo { get => _idInsumo; set => _idInsumo = value; }
        public string nombre { get => _nombre; set => _nombre = value; }
        public int estado { get => _estado; set => _estado = value; }
        public TipoInsumo tipoInsumo { get => _tipoInsumo; set => _tipoInsumo = value; }

        public Insumo(int idInsumo, TipoInsumo tipoInsumo, string nombre, int estado)
        {
            _idInsumo = idInsumo;
            _tipoInsumo = tipoInsumo;
            _nombre = nombre;
            _estado = estado;
        }

        public Insumo(int idInsumo, string nombre)
        {
            _idInsumo = idInsumo;
            _nombre = nombre;
        }

        public Insumo()
        {
        }
    }
}