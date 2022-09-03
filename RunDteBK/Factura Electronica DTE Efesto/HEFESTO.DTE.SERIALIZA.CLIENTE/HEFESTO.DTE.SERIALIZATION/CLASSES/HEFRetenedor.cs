using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    /// <summary>
    /// Obligatorio para agentes retenedores, 
    /// indica para cada transacción si es 
    /// agente retenedor del producto que 
    /// está vendiendo
    /// </summary>
    public class HEFRetenedor
    {
        /// <summary>
        /// #6 - IndAgente : Indicador Agente Retenedor
        /// Obligatorio para agentes retenedores, 
        /// indica para cada transacción si es 
        /// agente retenedor del producto que 
        /// está vendiendo
        /// </summary>
        public string IndAgente { get; set; }
        public bool ShouldSerializeIndAgente() { return (IndAgente == null || IndAgente.Length == 0) ? false : true; }

        
        /// <summary>
        /// #7 - MntBaseFaena : Monto Base Faenamiento
        /// Sólo para transacciones realizadas por 
        /// Agentes Retenedores, según códigos 
        /// de retención 17 
        /// </summary>
        public double MntBaseFaena { get; set; }
        public bool ShouldSerializeMntBaseFaena() { return (MntBaseFaena == null || MntBaseFaena == 0) ? false : true; }

        /// <summary>
        /// #8 - MntMargComer : Monto Base Márgenes de Comercialización
        /// Sólo para transacciones realizadas por 
        /// Agentes Retenedores, según códigos 
        /// de retención 14 y 50
        /// </summary>
        public double MntMargComer { get; set; }
        public bool ShouldSerializeMntMargComer() { return (MntMargComer == null || MntMargComer == 0) ? false : true; }

        /// <summary>
        /// #9 - PrcConsFinal : Precio Unitario Neto Consumidor Final
        /// Sólo para transacciones realizadas por 
        /// Agentes Retenedores, según códigos 
        /// de retención 14, 17 y 50 
        /// </summary>
        public double PrcConsFinal { get; set; }
        public bool ShouldSerializePrcConsFinal() { return (PrcConsFinal == null || PrcConsFinal == 0) ? false : true; }

    }

}
