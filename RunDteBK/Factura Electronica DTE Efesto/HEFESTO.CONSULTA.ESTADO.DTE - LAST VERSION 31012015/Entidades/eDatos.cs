using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.CONSULTA.ESTADO.DTE
{
    /// <summary>
    /// Datos para el procesamiento
    /// </summary>
    public class entDatos
    {
        
        public int indice { get; set; }
        public string RutConsultante { get; set; }
        public string RutCompania { get; set; }
        public string RutReceptor { get; set; }
        public string TipoDte { get; set; }
        public string Folio { get; set; }
        public string FechaEmisionDte { get; set; }
        public string MontoDte { get; set; }
        public string Token { get; set; }
        public string Estado { get; set; }
        public string GlosaEstado { get; set; }
        public string GlosaError { get; set; }
        ////
        //// Datos adicionales
        public string QueryRutConsultante { get; set; }
        public string QueryDvConsultante { get; set; }
        public string QueryRutCompania { get; set; }
        public string QueryDvCompania { get; set; }
        public string QueryRutReceptor { get; set; }
        public string QueryDvReceptor { get; set; }
        public string QueryFecha { get; set; }


        



    }
}
