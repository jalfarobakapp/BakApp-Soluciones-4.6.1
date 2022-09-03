using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HEFESTO.CONSULTA.TRACKID
{
    public class Respuesta
    {
        public bool EsCorrecto { get; set; }
        public string Mensaje { get; set; }
        public string Detalle { get; set; }
        public object Resultado { get; set; }
    }

    
}
