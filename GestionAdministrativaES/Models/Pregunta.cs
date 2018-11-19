using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAdministrativaES.Models
{
    public class Pregunta
    {
        private int _idPregunta;
        private int _idCuestionario;
        private string _pregunta;

        public int idPregunta { get => _idPregunta; set => _idPregunta = value; }
        public int idCuestionario { get => _idCuestionario; set => _idCuestionario = value; }
        public string pregunta { get => _pregunta; set => _pregunta = value; }

        public Pregunta(int idPregunta, int idCuestionario, string pregunta)
        {
            _idPregunta = idPregunta;
            _idCuestionario = idCuestionario;
            _pregunta = pregunta;
        }

        public Pregunta()
        {
        }
    }
}