using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.CONSULTA.ESTADO.DTE
{
    
    public class Respuesta
    {
        public bool EsCorrecto { get; set; }
        public string Mensaje { get; set; }
        public string Detalle { get; set; }
        public object Resultado { get; set; }
    }

    public class entRespuestaDTE
    {
        public string Estado { get; set; }
        public string Glosa { get; set; }
        public string EstadoDTE { get; set; }

    }

    public class RespuestaQuery : Respuesta
    {
        public string Estado { get; set; }
        public string GlosaEstado { get; set; }
        public string GlosaError { get; set; }
    
    
    }

}
