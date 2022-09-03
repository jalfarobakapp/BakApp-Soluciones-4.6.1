using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    /// <summary>
    /// Opcional para especificar 
    /// programación de pagos 
    /// del documento
    /// </summary>
    public class HEFMntPagos
    {
        /// <summary>
        /// #16 - Fecha de Pago         /// </summary>
        /// <remarks>
        /// Fecha de pago programado
        /// </remarks>
        public string FchPago { get; set; }

        /// <summary>
        /// #17 - Monto de Pago
        /// </summary>
        /// <remarks>
        /// Monto de pago programado
        /// </remarks>
        public double MntPago { get; set; }
        public bool ShouldSerializeMntPago() { return (MntPago == 0) ? false : true; }

        /// <summary>
        /// #18 - Glosa descripción Pago
        /// </summary>
        /// <remarks>
        /// Glosa Adicional para calificar pago
        /// </remarks>
        public string GlosaPagos { get; set; }


    }

}
