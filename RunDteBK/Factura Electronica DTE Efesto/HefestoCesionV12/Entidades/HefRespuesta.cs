using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HefestoCesionV12
{
    public class HefRespuesta
    {
        public HefRespuesta()
        {
            this.CodigoSII = -1;
            this.Trackid = "-1";
        }


        public bool EsCorrecto { get; set; }
        public string Mensaje { get; set; }
        public string Detalle { get; set; }
        public object Resultado { get; set; }
        public int CodigoSII { get; set; }
        public string Trackid { get; set; }

        /// <summary>
        /// Representa el nombre del archivo AEC generado.
        /// </summary>
        public string NombreArchivoAec { get; set; }

        /// <summary>
        /// Parametros de consulta
        /// </summary>
        public string Parametros { get; set; }

    }

}
