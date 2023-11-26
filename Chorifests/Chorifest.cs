using System;
using System.Runtime.Serialization;
using Microsoft.VisualBasic;

namespace Chorifests
{
    public class Chorifest
    {
        public int IDChorifest{
            get; set;
        }
        public string Titulo{
            get;
            set;
        } = ""; 
        public string Descripcion{
            get;
            set;
        } = "";
        public int Estado{
            get;
            set;
        }
        public DateTime Fecha{
            get;
            set;
        }
        public DateTime InicioFechaInscripcion{
            get;
            set;
        }
        public DateTime FinFechaInscripcion{
            get;
            set;
        }
        public int CantidadAsistentes{
            get;
            set;
        }

    }
}