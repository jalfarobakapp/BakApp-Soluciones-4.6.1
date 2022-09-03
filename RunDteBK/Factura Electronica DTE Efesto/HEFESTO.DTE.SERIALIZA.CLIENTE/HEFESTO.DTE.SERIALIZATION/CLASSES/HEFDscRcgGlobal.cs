/*

    DESCRIPCION

    Pueden ser de 0 hasta 20 líneas. Estos aumentan o disminuyen la base del impuesto. 
    Estos descuentos o recargos tienen una glosa que especifica el concepto. Por ejemplo un descuento global aplicado a un determinado tipo de 
    producto o un descuento por pago contado que afecta a todos los ítems. 
    En caso que se apliquen descuentos o recargos globales y 

    a) en la Zona de Detalle hayan ítems con distintos códigos de impuesto o retenciones, el campo “tipo de valor” del descuento debe ser %. 
 
    b) En la Zona de Detalle hayan algunos ítems afectos, otros exentos y otros no facturables (con “Indicador de Facturación Exención”=1 o 2), 
    hay tres casos: 
 
     Si el descuento afecta sólo a los ítems exentos se debe indicar un 1 en el “Indicador de Facturación/Exención” 
     Si el descuento afecta sólo a los ítems afectos no debe llevar el “Indicador de Facturación/Exención” 
     Si el descuento/recargo afecta sólo a los ítems no facturables se debe indicar un 2 en el “Indicador de Facturación/exención” 
     Si el descuento afecta a todos, deben haber tres líneas: Una con el descuento para el descuento de los afectos, otra para el descuento 
    de los exentos y otra para los no facturables. 


 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    /// <summary>
    /// INFORMACIÓN DE DESCUENTOS O RECARGOS 
    /// </summary>
    public class HEFDscRcgGlobal
    {

        /// <summary>
        /// Número de descuento o recargo. De 1 a 20.
        /// </summary>
        public int NroLinDR { get; set; }

        /// <summary>
        /// D(descuento) o R(recargo) 
        /// </summary>
        public string TpoMov { get; set; }

        /// <summary>
        /// Especificación de descuento o recargo 
        /// </summary>
        public string GlosaDR { get; set; }

        /// <summary>
        /// Indica si es Porcentaje o Monto 
        /// </summary>
        public string TpoValor { get; set; }

        /// <summary>
        /// Valor del descuento o recargo en 16  enteros y 2 decimales 
        /// </summary>
        public decimal ValorDR { get; set; }

        /// <summary>
        /// Indica si el descuento o recargo afecta a ítems exentos o no afectos a IVA. 
        /// </summary>
        [XmlElement]
        public int IndExeDR { get; set; }
        public bool ShouldSerializeIndExeDR()
        {
            return (IndExeDR == 0) ? false : true;
        }
    }


}
