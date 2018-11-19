using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class IncidenteInsumo
    {
        private int _idIncidenteInsumo;
        private Usuario _usuario;
        private Insumo _insumo;
        private string _fecha;
        private int _estado;

        public int idIncidenteInsumo { get => _idIncidenteInsumo; set => _idIncidenteInsumo = value; }
        public Usuario usuario { get => _usuario; set => _usuario = value; }
        public Insumo insumo { get => _insumo; set => _insumo = value; }
        public string fecha { get => _fecha; set => _fecha = value; }
        public int estado { get => _estado; set => _estado = value; }

        public IncidenteInsumo(int idIncidenteInsumo, Usuario usuario, Insumo insumo, string fecha, int estado)
        {
            _idIncidenteInsumo = idIncidenteInsumo;
            _usuario = usuario;
            _insumo = insumo;
            _fecha = fecha;
            _estado = estado;
        }

        public IncidenteInsumo()
        {
        }
    }
}