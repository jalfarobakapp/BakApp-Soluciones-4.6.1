using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    /// <summary>
    /// TABLA de Impuestos Adicionales y retenciones:
    /// Se pueden incluir 20 repeticiones de 
    /// pares código – valor. Incluye los dos 
    /// campos siguientes. 
    /// </summary>
    public class HEFImptoReten
    {
        /// <summary>
        /// #111 - Código de Impuesto adicional o Retención
        /// </summary>
        /// <remarks>
        /// Código del impuesto o retención de 
        /// acuerdo a la codificación detallada en 
        /// tabla de códigos (ver Punto 4 del índice). 
        /// Incluye Retención de Cambio sujeto de Construcción
        /// </remarks>
        /// <example>
        /// Código válido de impuesto 
        /// o retención (Ver Índice 4.- 
        /// Codificación Tipos de Impuesto) 
        /// </example>
        public string TipoImp { get; set; }

        /// <summary>
        /// #112 - Tasa de Impuesto o Retención 
        /// </summary>
        /// <remarks>
        /// Se debe indicar la tasa de Impuesto 
        /// adicional o retención. En el caso de 
        /// impuesto específicos se puede omitir
        /// </remarks>
        /// <example>
        /// Según las tasa válidas al 
        /// momento de la transacción. 
        /// </example>
        public string TasaImp { get; set; }

        /// <summary>
        /// #113 - Valor del Impuesto o Retención. 
        /// </summary>
        /// <remarks>
        /// Valor del impuesto o retención 
        /// asociado al código indicado 
        /// anteriormente
        /// </remarks>
        /// <example>
        /// a) Tasa* (Suma de líneas 
        /// de detalle con código 
        /// de Impuesto adicional 
        /// o retención), excepto 
        /// Diesel, Gasolina, 
        /// margen de 
        /// comercialización e “Iva 
        /// anticipado faenamiento 
        /// carne” 
        /// b) Tasa * Monto base 
        /// faenamiento para Iva 
        /// anticipado faenamiento 
        /// carne 
        /// c) Valor numérico en 
        /// otros casos > 0
        /// </example>
        public double MontoImp { get; set; }

    }
}
