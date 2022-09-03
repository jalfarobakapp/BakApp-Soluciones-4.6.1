using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    /// <summary>
    /// Representa los codigos internos de la empresa para un determinado item 
    /// del detalle del documento.
    /// </summary>
    public class HEFCdgItem
    {
        /// <summary>
        /// Tipo de codigo interno del elemento detalle actual
        /// </summary>
        public string TpoCodigo { get; set; }

        /// <summary>
        /// Valor de codigo interno del elemento detalle actual
        /// </summary>
        public string VlrCodigo { get; set; }

    }

}
