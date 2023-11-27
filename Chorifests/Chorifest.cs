using System;
using System.Runtime.Serialization;
using Microsoft.VisualBasic;
using Personas;

namespace Chorifests
{
    public class Chorifest
    {
        public int ChorifestID
        {
            get; 
            set;
        }
        public int MenuID
        {
            get;
            set;
        } = 0;
        public string Titulo
        {
            get;
            set;
        } = ""; 
        public string Descripcion
        {
            get;
            set;
        } = "";
        public int Estado
        {
            get;
            set;
        }
        public DateTime Fecha
        {
            get;
            set;
        }
        public DateTime InicioFechaInscripcion
        {
            get;
            set;
        }
        public DateTime FinFechaInscripcion
        {
            get;
            set;
        }
        public int CantidadAsistentes
        {
            get;
            set;
        }
    }
}