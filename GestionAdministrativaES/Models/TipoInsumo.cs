using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class TipoInsumo
    {
        private int _idTipoInsumo;
        private string _nombre;

        public int idTipoInsumo { get => _idTipoInsumo; set => _idTipoInsumo = value; }
        public string nombre { get => _nombre; set => _nombre = value; }

        public TipoInsumo(int idTipoInsumo, string nombre)
        {
            _idTipoInsumo = idTipoInsumo;
            _nombre = nombre;
        }

        public TipoInsumo()
        {
        }
    }
}