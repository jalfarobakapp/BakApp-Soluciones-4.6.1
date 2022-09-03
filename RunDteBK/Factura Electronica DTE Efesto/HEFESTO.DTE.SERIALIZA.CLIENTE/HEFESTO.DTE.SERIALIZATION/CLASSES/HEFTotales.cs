using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{

    /// <summary>
    /// Representa la totalera del documento DTE actual
    /// </summary>
    public class HEFTotales
    {

        /// <summary>
        /// #102 -Tipo Moneda Transacción 
        /// </summary>
        /// <remarks>
        /// Moneda en que se registra la 
        /// transacción de exportación.
        /// </remarks>
        public double TpoMoneda { get; set; }
        public bool ShouldSerializeTpoMoneda() { return (TpoMoneda == 0) ? false : true; }

        /// <summary>
        /// #103 - Monto neto
        /// </summary>
        /// <remarks>
        /// Suma de valores total de ítems afectos - descuentos globales + recargos 
        /// globales (Asignados a ítems afectos). Si está encendido el Indicador de 
        /// Montos Brutos (=1) entonces el resultado anterior se debe dividir por 
        /// (1 + tasa de IVA) 
        /// </remarks>
        /// <example>
        /// Valor numérico de acuerdo a descripción. En Liquidaciones-Factura 
        /// puede tomar valor negativo
        /// </example>
        public double MntNeto { get; set; }

        /// <summary>
        /// #104 - Monto no afecto o exento
        /// </summary>
        /// <remarks>
        /// Suma de valores total de ítems no 
        /// afectos o exentos -descuentos 
        /// globales + recargos globales 
        /// (Asignados a ítems exentos o no 
        /// afectos) 
        /// </remarks>
        public double MntExe { get; set; }

        /// <summary>
        /// #105 - Monto base faenamiento carne
        /// </summary>
        /// <remarks>
        /// Monto informado
        /// </remarks>
        public double MntBase { get; set; }
        public bool ShouldSerializeMntBase() { return (MntBase == 0) ? false : true; }

        /// <summary>
        /// #106 - Monto Base de Márgenes de Comercialización
        /// </summary>
        /// <remarks>
        /// Monto informado
        /// </remarks>
        public double MntMargenCom { get; set; }
        public bool ShouldSerializeMntMargenCom() { return (MntMargenCom == 0) ? false : true; }

        /// <summary>
        /// #107 - Tasa IVA
        /// </summary>
        /// <example>19</example>
        public int TasaIVA { get; set; }

        /// <summary>
        /// #108 - IVA
        /// </summary>
        public double IVA { get; set; }
        

        /// <summary>
        /// #109 - IVA Propio
        /// </summary>
        /// <remarks>
        /// Las empresas que venden por cuenta 
        /// de un mandatario, pueden opcional 
        /// separar el IVA en propio y de terceros. 
        /// En todos estos casos el campo “IVA” 
        /// debe contener el IVA total de la 
        /// Factura 
        /// </remarks>
        public double IVAProp { get; set; }
        public bool ShouldSerializeIVAProp() { return (IVAProp == 0) ? false : true; }

        /// <summary>
        /// #110 - IVA Terceros
        /// </summary>
        /// <remarks>
        /// Ídem al anterior
        /// </remarks>
        public double IVATerc { get; set; }
        public bool ShouldSerializeIVATerc() { return (IVATerc == 0) ? false : true; }

        ////////////////////////////////////////////////////
        //// tabla <ImptoReten> hasta 20 repeticiones
        ////////////////////////////////////////////////////
        public List<HEFImptoReten> _ImptoReten;
        
        /// <summary>
        /// Regresa el arreglo de impuestos y retenciones
        /// </summary>
        [XmlElement("ImptoReten")]
        public List<HEFImptoReten> ImptoReten { get; set; }





        ////////////////////////////////////////////////////
        //// Fin tabla <ImptoReten>
        ////////////////////////////////////////////////////

        /// <summary>
        /// #114 - IVA no retenido
        /// </summary>
        /// <remarks>
        /// Sólo en facturas de Compra en que 
        /// hay retención de IVA por el emisor y 
        /// Notas de Crédito o débito que 
        /// referencian facturas de compra. 
        /// No se registra si es igual a 0
        /// </remarks>
        public double IVANoRet { get; set; }
        public bool ShouldSerializeIVANoRet() { return (IVANoRet == 0) ? false : true; }

        /// <summary>
        /// #115 - Crédito especial 
        /// 65% Empresas 
        /// Constructoras 
        /// </summary>
        /// <remarks>
        /// Artículo 21 del decreto ley N° 910/75. 
        /// Este Es el único código que opera en 
        /// forma opuesta al resto, ya que se resta 
        /// al IVA general 
        /// </remarks>
        public double CredEC { get; set; }
        public bool ShouldSerializeCredEC() { return (CredEC == 0) ? false : true; }

        /// <summary>
        /// #116 - Garantía por depósito de envases o embalajes (no afecto) 
        /// </summary>
        /// <remarks>
        /// Sólo para empresas que usen envases 
        /// en forma habitual, por su giro principal. 
        /// Art.28,Inc3 Reglamento DL 825) 
        /// (Cervezas, Jugos, Aguas Minerales, 
        /// Bebidas Analcohólicas u otros 
        /// autorizados por Resolución especial). 
        /// Corresponde a la Sumatoria de las 
        /// líneas de detalle que indican Indicador
        /// de facturación/ exención = 3
        /// </remarks>
        public double GrntDep { get; set; }
        public bool ShouldSerializeGrntDep() { return (GrntDep == 0) ? false : true; }

        /// <summary>
        /// #117 - Valor Neto Comisiones y Otros Cargos 
        /// </summary>
        /// <remarks>
        /// Suma de detalle de Valores de 
        /// Comisiones y Otros Cargos 
        /// </remarks>
        public double ValComNeto { get; set; }
        public bool ShouldSerializeValComNeto() { return (ValComNeto == 0) ? false : true; }

        /// <summary>
        /// #118 -  Valor Comisiones y Otros Cargos No Afectos o Exentos
        /// </summary>
        /// <remarks>
        /// Suma de detalles de valores de 
        /// comisiones y otros cargos no afectos o 
        /// exentos 
        /// </remarks>
        public double ValComExe { get; set; }
        public bool ShouldSerializeValComExe() { return (ValComExe == 0) ? false : true; }


        /// <summary>
        /// #119 - IVA Comisiones y Otros Cargos
        /// </summary>
        /// <remarks>
        /// Suma de detalle de IVA de Valor de 
        /// Comisiones y Otros Cargos
        /// </remarks>
        public double ValComIVA { get; set; }
        public bool ShouldSerializeValComIVA() { return (ValComIVA == 0) ? false : true; }

        /// <summary>
        /// #120 - Monto Total 
        /// </summary>
        /// <remarks>
        /// Monto neto + Monto no afecto o 
        /// exento + IVA + Impuestos Adicionales 
        /// + Impuestos Específicos + Iva Margen 
        /// Comercialización +IVA Anticipado + 
        /// Garantía por depósito de envases o 
        /// embalajes - Crédito empresas 
        /// constructoras- IVA Retenido productos 
        /// (en caso de facturas de compra) - 
        /// Valor Neto Comisiones y Otros Cargos 
        /// - IVA Comisiones y Otros Cargos - 
        /// Valor Comisiones y Otros Cargos No 
        /// Afectos o Exentos. 
        /// (Los Impuestos Adicionales y el IVA 
        /// Anticipado están detallados en la 
        /// TABLA de Impuestos Adicionales y 
        /// Retenciones) 
        /// </remarks>
        public double MntTotal { get; set; }

        /// <summary>
        /// #121 - Monto no facturable
        /// </summary>
        /// <remarks>
        /// Suma de montos de bienes o servicios 
        /// con Indicador de facturación/ exención 
        /// = 2 menos Suma de montos de bienes 
        /// o servicios con Indicador de 
        /// facturación/ exención = 6 
        /// </remarks>
        public double MontoNF { get; set; }
        public bool ShouldSerializeMontoNF() { return (MontoNF == 0) ? false : true; }

        /// <summary>
        /// #122 - Monto periodo
        /// </summary>
        /// <remarks>
        /// Monto Total + Monto no Facturable 
        /// </remarks>
        public double MontoPeriodo { get; set; }
        public bool ShouldSerializeMontoPeriodo() { return (MontoPeriodo == 0) ? false : true; }

        /// <summary>
        /// #123 - Saldo Anterior 
        /// </summary>
        /// <remarks>
        /// Saldo Anterior. Se incluye sólo con 
        /// fines de ilustrar con claridad el cobro.
        /// </remarks>
        public double SaldoAnterior { get; set; }
        public bool ShouldSerializeSaldoAnterior() { return (SaldoAnterior == 0) ? false : true; }

        /// <summary>
        /// #124 - Valor a pagar
        /// </summary>
        /// <remarks>
        /// Valor cobrado
        /// </remarks>
        public double VlrPagar { get; set; }
        public bool ShouldSerializeVlrPagar() { return (VlrPagar == 0) ? false : true; }

    }
}
