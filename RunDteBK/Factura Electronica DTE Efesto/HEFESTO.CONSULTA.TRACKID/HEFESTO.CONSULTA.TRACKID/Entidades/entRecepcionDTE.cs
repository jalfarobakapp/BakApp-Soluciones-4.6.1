using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.CONSULTA.TRACKID
{
    public class entRecepcionDTE
    {
        /// <summary>
        /// Id del estado de recepcion del envio al SII
        /// </summary>
        public int EstadoID { get; set; }

        /// <summary>
        /// Representa el estado literal del envio al SII
        /// </summary>
        public string EstadoLiteral { get; set; }
    }
}
