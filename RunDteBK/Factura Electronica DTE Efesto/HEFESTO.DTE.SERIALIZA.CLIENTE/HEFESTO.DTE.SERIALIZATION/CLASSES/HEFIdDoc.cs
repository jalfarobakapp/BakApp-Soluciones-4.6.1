/*
 
TIPOS DE DOCUMENTO DISPONIBLES 

33: Factura Electrónica 
34: Factura No Afecta o Exenta 
Electrónica 
43: Liquidación-Factura Electrónica 
46: Factura de Compra Electrónica. 
52: Guía de Despacho Electrónica 
56: Nota de Débito Electrónica 
61: Nota de Crédito Electrónica 
110: Factura de Exportación. 
111: Nota de Débito de Exportación. 
112: Nota de Crédito de Exportación.
 
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HEFESTO.DTE.SERIALIZATION.CLASSES
{
    /// <summary>
    /// Representa la zona de identificacion del documento DTE
    /// </summary>
    public class HEFIdDoc
    {

        ////
        //// Colecciones
        private List<HEFMntPagos> _MntPagos = new List<HEFMntPagos>();


        /// <summary>
        /// #2 - Tipo Documento Tributario Electrónico
        /// </summary>
        /// <remarks>
        /// 33: Factura Electrónica 
        /// 34: Factura No Afecta o Exenta Electrónica 
        /// 43: Liquidación-Factura Electrónica 
        /// 46: Factura de Compra Electrónica. 
        /// 52: Guía de Despacho Electrónica 
        /// 56: Nota de Débito Electrónica 
        /// 61: Nota de Crédito Electrónica 
        /// 110: Factura de Exportación. 
        /// 111: Nota de Débito de Exportación. 
        /// 112: Nota de Crédito de Exportación.
        /// </remarks>
        public int TipoDTE { get; set; }

        /// <summary>
        /// #3 - Folio Documento 
        /// </summary>
        /// <remarks>
        /// Folio autorizado por el SII 
        /// </remarks>
        public long Folio { get; set; }

        /// <summary>
        /// #4 - Fecha de Emisión
        /// </summary>
        /// <example>
        /// Fecha de emisión contable del docto (AAAA-MM-DD) 
        /// </example>
        public string FchEmis { get; set; }

        /// <summary>
        /// #5 - Indicador de No Rebaja 
        /// </summary>
        /// <remarks>
        /// Sólo para Notas de Crédito que no 
        /// tienen derecho a Rebaja del Débito
        /// </remarks>
        public int IndNoRebaja { get; set; }
        public bool ShouldSerializeIndNoRebaja(){ return (IndNoRebaja == 0) ? false : true; }

        /// <summary>
        /// #6 - Tipo de Despacho
        /// </summary>
        /// <remarks>
        /// Indica si el documento acompaña bienes y el despacho es por cuenta 
        /// del vendedor o del comprador. No se incluye si el documento no 
        /// acompaña bienes o se trata de una Factura o Nota correspondiente a la 
        /// prestación de servicios. 
        /// </remarks>
        public int TipoDespacho { get; set; }
        public bool ShouldSerializeTipoDespacho() { return (TipoDespacho == 0) ? false : true; }


        /// <summary>
        /// #7 - Indicador Tipo de traslado de bienes 
        /// </summary>
        /// <remarks>
        /// Sólo para Guías de despacho. Indica si el traslado de mercadería es 
        /// por Venta (valor 1) o por otros motivos que no corresponden a 
        /// venta. (valores mayores a 1). 7: Para de devolución de mercaderías 
        /// que fueron trasladadas para exportación desde la zona de 
        /// embarque.. 8 y 9: Para exportaciones, cuando se 
        /// dirige la mercadería hacia el puerto, 
        /// aeropuerto o aduana de embarque. 
        /// 9 : Entre otros, venta de mercaderías 
        /// que se entregan en Zona Primaria de 
        /// Aduanas para su exportación 
        /// </remarks>
        /// <example>
        /// 1: Operación constituye venta
        /// 2: Ventas por efectuar 
        /// 3: Consignaciones 
        /// 4: Entrega gratuita 
        /// 5: Traslados internos 
        /// 6: Otros traslados no venta 
        /// 7: Guía de devolución 
        /// 8: Traslado para exportación. (no venta) 
        /// 9: Venta para exportación
        /// </example>
        public int IndTraslado { get; set; }
        public bool ShouldSerializeIndTraslado() { return (IndTraslado == 0) ? false : true; }


        /// <summary>
        /// #8 - Tipo de impresión
        /// </summary>
        /// <remarks>
        /// Describe modalidad de Impresión de 
        /// la representación impresa en formato 
        /// normal o en formato Ticket 
        /// </remarks>
        /// <example>
        /// N (Normal) o T (Ticket) Por omisión se asume “N”
        /// </example>
        public int TpoImpresion { get; set; }
        public bool ShouldSerializeTpoImpresion() { return (TpoImpresion == 0) ? false : true; }


        /// <summary>
        /// #9 - Indicador Servicio
        /// </summary>
        /// <remarks>
        /// Indica si la transacción corresponde a la prestación de un servicio
        /// </remarks>
        /// <example>
        /// 1: Factura de servicios periódicos domiciliarios
        /// 2: Factura de otros servicios periódicos 
        /// 3: Factura de Servicios. (en caso de Factura de Exportación: Servicios calificados como tal por Aduana) Sólo para Facturas de Exportación: 
        /// 4: Servicios de Hotelería 
        /// 5: Servicio de Transporte Terrestre Internacional 
        /// </example>
        public int IndServicio { get; set; }
        public bool ShouldSerializeIndServicio() { return (IndServicio == 0) ? false : true; }

        /// <summary>
        /// #10 - Indicador Montos Brutos 
        /// </summary>
        /// <remarks>
        /// Indica si las líneas de detalle, descuentos y recargos se expresan 
        /// en montos brutos. (Sólo para 
        /// documentos sin impuestos 
        /// adicionales) . 
        /// </remarks>
        /// <example>
        /// 1: Montos de líneas de detalle vienen expresados en montos brutos.
        /// </example>
        public int MntBruto { get; set; }
        public bool ShouldSerializeMntBruto() { return (MntBruto == 0) ? false : true; }

        /// <summary>
        /// #sn - Tipo de Transacción para el comprador
        /// </summary>
        /// <remarks>MR:19-06-2019</remarks>
        public int TpoTranCompra { get; set; }
        public bool ShouldSerializeTpoTranCompra() { return (TpoTranCompra == 0) ? false : true; }

        /// <summary>
        /// #sn - Tipo de Transacción para el comprador
        /// </summary>
        /// <remarks>MR:19-06-2019</remarks>
        public int TpoTranVenta { get; set; }
        public bool ShouldSerializeTpoTranVenta() { return (TpoTranVenta == 0) ? false : true; }
        
        /// <summary>
        /// #11 - Forma de Pago 
        /// </summary>
        /// <remarks>
        /// Indica en qué forma se pagará. En el caso de una Factura por “Entrega 
        /// Gratuita”, se debe indicar el 3. Una Factura de este tipo no tiene derecho 
        /// a crédito fiscal.
        /// </remarks>
        /// <example>
        /// Valor 
        /// 1: Contado;
        /// 2: Crédito 
        /// 3: Sin costo (entrega gratuita)
        /// </example>
        public int FmaPago { get; set; }
        public bool ShouldSerializeFmaPago() { return (FmaPago == 0) ? false : true; }

        /// <summary>
        /// #12 - Forma de Pago Exportación 
        /// </summary>
        /// <remarks>
        /// En el caso de Factura de exportación se refiere a la forma de pago del 
        /// importador extranjero indicada en el DUS (acreditivo, cobranza, anticipo, 
        /// contado) En el caso de una Factura de exportación por “Muestras sin
        /// carácter comercial”, según las normas de Aduanas, debe indicar el Cod. 21. 
        /// </remarks>
        public int FmaPagExp { get; set; }
        public bool ShouldSerializeFmaPagExp() { return (FmaPagExp == 0) ? false : true; }


        /// <summary>
        /// #13 - Fecha de cancelación 
        /// </summary>
        /// <remarks>
        /// Sólo se utiliza si la factura ha sido cancelada antes de la fecha de 
        /// emisión. (AAAA-MM-DD) 
        /// </remarks>
        /// <example>
        /// Fecha válida entre 2002-08-01 y 2050-12-31 Campo Obligatorio para 
        /// Factura de exportación cuando en “Forma de Pago Exportación” se 
        /// indique “anticipo”
        /// </example>
        public int FchCancel { get; set; }
        public bool ShouldSerializeFchCancel() { return (FchCancel == 0) ? false : true; }

        /// <summary>
        /// #14 - Monto Cancelado
        /// </summary>
        /// <remarks>
        /// Monto Cancelado al momento de emitirse el documento
        /// </remarks>
        public long MntCancel { get; set; }
        public bool ShouldSerializeMntCancel() { return (MntCancel == 0) ? false : true; }

        /// <summary>
        /// #15 - Saldo Insoluto
        /// </summary>
        /// <remarks>
        /// Saldo Insoluto al momento de emitirse el documento
        /// </remarks>
        public long SaldoInsol { get; set; }
        public bool ShouldSerializeSaldoInsol() { return (SaldoInsol == 0) ? false : true; }

        ///////////////////////////////////////////////////////////////
        //// TABLA de Montos de Pago <MntPagos>
        //// 16,17,18
        ///////////////////////////////////////////////////////////////
        [XmlElement("MntPagos")]
        public List<HEFMntPagos> MntPagos
        {
            get { return _MntPagos; }
            set { _MntPagos = value; }
        }


        /// <summary>
        /// #19 - Periodo desde
        /// </summary>
        /// <remarks>
        /// Período de facturación para Servicios 
        /// Periódicos. Fecha desde 
        /// (Fecha inicial del servicio facturado) 
        /// </remarks>
        public string  PeriodoDesde { get; set; }

        /// <summary>
        /// #20 - Periodo hasta
        /// </summary>
        /// <remarks>
        /// Período de facturación para Servicios 
        /// Periódicos. Fecha hasta 
        /// (Fecha final del servicio facturado)
        /// </remarks>
        public string PeriodoHasta { get; set; }


        /// <summary>
        /// #21 - Medio de pago
        /// </summary>
        /// <remarks>
        /// Indica en que modalidad se pagará. 
        /// </remarks>
        /// <example>
        /// Valor: 
        /// CH: Cheque; 
        /// CF: Cheque a fecha 
        /// LT:letra,EF:Efectivo, 
        /// PE: Pago A Cta. Cte.; 
        /// TC:Tarjeta Crédito, 
        /// OT:Otro
        /// </example>
        public string MedioPago { get; set; }

        ///// <summary>
        ///// #22 - Tipo cuenta de pago
        ///// </summary>
        ///// <remarks>
        ///// Cuenta
        ///// </remarks>
        ///// <example>
        ///// Valor: CT: Cta.Cte; AH:Ahorro, OT:Otra. 
        ///// </example>
        ///// public string TipoCtaPago { get; set; }

        /// <summary>
        /// #22 - Tipo cuenta de pago
        /// </summary>
        /// <remarks>
        /// Cuenta
        /// </remarks>
        /// <example>
        /// Valor: CT: Cta.Cte; AH:Ahorro, OT:Otra. 
        /// </example>
        public string TpoCtaPago { get; set; }
        

        /// <summary>
        /// #23 - Cuenta de pago
        /// </summary>
        /// <remarks>
        /// Numero de la Cuenta 
        /// </remarks>
        public string NumCtaPago { get; set; }

        /// <summary>
        /// #24 - Banco de pago
        /// </summary>
        /// <remarks>Banco de la Cuenta</remarks>
        public string BcoPago { get; set; }


        /// <summary>
        /// #25 - Términos del pago- Código
        /// </summary>
        /// <remarks>
        /// Es un código acordado entre las 
        /// empresas, que indica términos de 
        /// referencia
        /// </remarks>
        /// <example>
        /// Fecha Recepción Factura (FRF)
        /// Fecha entrega Mercaderías (FEM)
        /// </example>
        public string TermPagoCdg { get; set; }

        /// <summary>
        /// #26 - Términos del Pago – glosa
        /// </summary>
        /// <remarks>
        /// Glosa que describe las condiciones del pago del documento codificado en el campo:
        /// "Términos del pago Código"
        /// </remarks>
        public string TermPagoGlosa { get; set; }

        /// <summary>
        /// #27 - Términos del pago - dias
        /// </summary>
        /// <remarks>
        /// Cantidad de días de acuerdo al código de Términos de pago
        /// </remarks>
        /// <example>
        /// 5 días Fecha entrega Mercaderías 
        /// (Día = 5, Código =FEM) 
        /// </example>
        public int TermPagoDias { get; set; }
        public bool ShouldSerializeTermPagoDias() { return (TermPagoDias == 0) ? false : true; }

        /// <summary>
        /// #28 - Fecha de vencimiento (pago)
        /// </summary>
        /// <remarks>
        /// Fecha de vencimiento (AAA-MM-DD ), FECHA VALIDA 2002-08-01 y 2050-12-31
        /// </remarks>
        public string FchVenc { get; set; }

        /// <summary>
        /// Tipo de Factura Especial
        /// </summary>
        public int TipoFactEsp { get; set; }
        
    }
}
